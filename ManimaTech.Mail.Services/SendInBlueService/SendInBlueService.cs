using ManimaTech.Notification.Domain.Model.Message;
using ManimaTech.Notification.Dtos;
using ManimaTech.Notification.Models.Settings;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace ManimaTech.Notification.Services.SendInBlueService
{
    public class SendInBlueService : ISendInBlueService
    {
        private readonly AppSettings _appSettings;

        public SendInBlueService(AppSettings appSettings) 
        { 
            _appSettings = appSettings;
        }

        public async Task<string> Send(MessageModel messageModel)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_appSettings.SendInBlueSettings.Url);
            httpClient.DefaultRequestHeaders.Add("api-key", _appSettings.SendInBlueSettings.ApiKey);

            var request = JsonConvert.SerializeObject(new SendInBlueRequestDto
            {
                HtmlContent = HttpUtility.HtmlDecode(messageModel.Message),
                Sender = new Sender
                {
                    Email = messageModel.Sender.Value,
                    Name = messageModel.Sender.Name
                },
                To = new List<To>
                {
                    { 
                        new To
                        {
                            Email = messageModel.Receiver.Value,
                            Name = messageModel.Receiver.Name
                        } 
                    }
                },
                Subject = messageModel.Subject
            });

            StringContent content = new(request, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync("/v3/smtp/email", content);

            if(result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStringAsync();

                return stream;
            }

            var error = await result.Content.ReadAsStringAsync();

            throw new InvalidOperationException($"Error sending mail: {error}");
        }
    }
}
