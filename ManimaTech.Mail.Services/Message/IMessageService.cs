using ManimaTech.Notification.Domain.Model.Message;
using ManimaTech.Notification.Enum;

namespace ManimaTech.Notification.Services.Message
{
    public interface IMessageService
    {
        Task<MessageModel> UpdateStatus(string id, MessageStatusType status);
        Task<MessageModel> UpdateStatusWithResult(string id, MessageStatusType status, string result);
        Task<MessageModel> GetById(string id);
    }
}
