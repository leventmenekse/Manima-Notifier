using RabbitMQ.Client;

namespace ManimaTech.Notification.Services.RabbitMQ
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
    }
}
