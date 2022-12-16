using ManimaTech.Notification.Enum;
using ManimaTech.Notification.Models.Settings;
using ManimaTech.Notification.Services;
using ManimaTech.Notification.Services.Mandrill;
using ManimaTech.Notification.Services.Message;
using ManimaTech.Notification.Services.RabbitMQ;
using ManimaTech.Notification.Services.SendGrid;
using ManimaTech.Notification.Services.SendInBlue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ManimaTech.Notification.Sender
{
    public class Runner
    {
        private readonly IMessageService _messageService;
        private readonly IRabbitMQService _rabbitMqService;
        private readonly AppSettings _appSettings;
        private readonly Dictionary<string, IEmailClient> _emailClients;

        public Runner(IMessageService messageService, 
            IRabbitMQService rabbitMqService, 
            AppSettings appSettings,
            ISendInBlueService sendInBlueService,
            ISendGridService sendGridService,
            IMandrillService mandrillService)
        {
            _messageService = messageService;
            _rabbitMqService = rabbitMqService;
            _appSettings = appSettings;

            _emailClients = new Dictionary<string, IEmailClient>
            {
                { EmailClientsType.SEND_IN_BLUE.ToString(), sendInBlueService },
                { EmailClientsType.SEND_GRID.ToString(), sendGridService },
                { EmailClientsType.MANDRILL.ToString(), mandrillService }
            };
        }

        public async Task Run()
        {
            var connection = _rabbitMqService.GetConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(_appSettings.RabbitMQ.ExchangeName, ExchangeType.Fanout, true, false, null);
            channel.QueueDeclare(_appSettings.RabbitMQ.QueueName, true, false, false, null);
            channel.QueueBind(_appSettings.RabbitMQ.QueueName, _appSettings.RabbitMQ.ExchangeName, _appSettings.RabbitMQ.RoutingKey);
            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) => ConsumeMessage(sender, ea);

            channel.BasicConsume(_appSettings.RabbitMQ.QueueName, false, consumer);
        }

        private async Task ConsumeMessage(object sender, BasicDeliverEventArgs ea)
        {
            var rawMessage = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(rawMessage);
            EventingBasicConsumer channel = ((EventingBasicConsumer)sender);

            try
            {
                var model = await _messageService.UpdateStatus(message, MessageStatusType.PROCESSING);
                
                if (model == null)
                {
                    Console.WriteLine("Model not found");
                    channel.Model.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);

                    return;
                }

                var result = await _emailClients[model.Router].Send(model);
                await _messageService.UpdateStatusWithResult(message, MessageStatusType.SUCCEED, result);

                channel.Model.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Mail send exception {ex.Message}");
                await _messageService.UpdateStatusWithResult(message, MessageStatusType.FAILED, ex.Message);
                //TODO Setup requeue strategy
                channel.Model.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);
            }
        }
    }
}
