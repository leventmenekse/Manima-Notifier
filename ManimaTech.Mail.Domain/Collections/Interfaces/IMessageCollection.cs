using ManimaTech.Notification.Domain.Base.Interfaces;
using ManimaTech.Notification.Domain.Model.Message;

namespace ManimaTech.Notification.Domain.Collections.Interfaces
{
    public interface IMessageCollection : IBaseCollection<MessageModel>
    {
        Task<MessageModel> UpdateStatus(string id, string status);
        Task<MessageModel> UpdateStatusWithResult(string id, string status, string result);
    }
}
