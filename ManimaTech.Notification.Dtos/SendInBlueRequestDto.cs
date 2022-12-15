using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ManimaTech.Notification.Dtos
{
    public class SendInBlueRequestDto
    {
        [JsonProperty(PropertyName = "sender")]
        public Sender Sender { get; set; }

        [JsonProperty(PropertyName = "to")]
        public List<To> To { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "htmlContent")]
        public string HtmlContent { get; set; }
    }

    public class Sender
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }

    public class To
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}