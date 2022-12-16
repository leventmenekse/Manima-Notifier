using Mandrill;
using Mandrill.Models;
using ManimaTech.Notification.Domain.Model.Message;
using ManimaTech.Notification.Models.Settings;
using Newtonsoft.Json;
using System.Web;
using Messages = Mandrill.Requests.Messages;

namespace ManimaTech.Notification.Services.Mandrill
{
    public class MandrillService : IMandrillService
    {
        private readonly AppSettings _appSettings;

        public MandrillService(AppSettings appSettings) 
        {
            _appSettings = appSettings;
        }
        public async Task<string> Send(MessageModel messageModel)
        {
            MandrillApi api = new(_appSettings.MandrillSettings.ApiKey);

            var emailMessage = new EmailMessage
            {
                FromEmail = messageModel.Sender.Value,
                FromName = messageModel.Sender.Name,
                To = new List<EmailAddress>
                {
                    new EmailAddress
                    {
                        Email = messageModel.Receiver.Value,
                        Name= messageModel.Receiver.Name
                    }
                },
                Subject = messageModel.Subject,
                Html = HttpUtility.HtmlDecode(messageModel.Message)
            };

            var result = await api.SendMessage(new Messages.SendMessageRequest(emailMessage));

            if (result == null || !result.Any())
                throw new InvalidOperationException("Error sending mail: result is null");

            if (result?.FirstOrDefault()?.Status != EmailResultStatus.Sent)
                throw new InvalidOperationException($"Error sending mail: {JsonConvert.SerializeObject(result)}");

            return JsonConvert.SerializeObject(result);
        }
    }
}
