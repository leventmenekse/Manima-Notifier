using ManimaTech.Notification.Domain.Model.Message;
using ManimaTech.Notification.Models.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web;

namespace ManimaTech.Notification.Services.SendGrid
{
    public class SendGridService : ISendGridService
    {
        private readonly AppSettings _appSettings;
        public SendGridService(AppSettings appSettings) 
        { 
            _appSettings = appSettings;
        }

        public async Task<string> Send(MessageModel messageModel)
        {
            var client = new SendGridClient(_appSettings.SendGridSettings.ApiKey);
            var from = new EmailAddress(messageModel.Sender.Value, messageModel.Sender.Name);
            var to = new EmailAddress(messageModel.Receiver.Value, messageModel.Receiver.Name);

            var request = MailHelper.CreateSingleEmail(from, to, messageModel.Subject, string.Empty, HttpUtility.HtmlDecode(messageModel.Message));

            var result = await client.SendEmailAsync(request);

            if (result.IsSuccessStatusCode)
            {
                return await result.Body.ReadAsStringAsync();
            }

            var error = await result.Body.ReadAsStringAsync();

            throw new InvalidOperationException($"Error sending mail: {error}");
        }
    }
}
