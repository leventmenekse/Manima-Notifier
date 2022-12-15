using ManimaTech.Notification.Domain.Model.Message;

namespace ManimaTech.Notification.Services
{
    public interface IEmailClient
    {
        Task<string> Send(MessageModel messageModel);
    }
}
