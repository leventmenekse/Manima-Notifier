using ManimaTech.Notification.Models.Settings;
using RabbitMQ.Client;

namespace ManimaTech.Notification.Services.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly AppSettings _appSettings;

        public RabbitMQService(AppSettings appSettings) 
        { 
            _appSettings = appSettings;
        }

        public IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = _appSettings.RabbitMQ.HostName,
                UserName = _appSettings.RabbitMQ.Username,
                Password = _appSettings.RabbitMQ.Password,
                VirtualHost = _appSettings.RabbitMQ.VirtualHost
            };

            return connectionFactory.CreateConnection();
        }
    }
}
