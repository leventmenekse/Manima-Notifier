namespace ManimaTech.Notification.Models.Settings
{
    public class AppSettings
    {
        public MongoDb MongoDb { get; set; }
        public RabbitMQ RabbitMQ { get; set; }
        public SendInBlueSettings SendInBlueSettings { get; set; }
        public SendGridSettings SendGridSettings { get; set; }
        public MandrillSettings MandrillSettings { get; set; }
    }

    public class MongoDb {
        public string ConnectionString { get; set; }
    }

    public class RabbitMQ
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string QueueName { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
    }

    public class SendInBlueSettings
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
    } 

    public class SendGridSettings
    {
        public string ApiKey { get; set; }
    }

    public class MandrillSettings
    {
        public string ApiKey { get; set; }
    }
}
