using ManimaTech.Notification.Domain.Collections.Interfaces;
using ManimaTech.Notification.Domain.Model.Message;
using ManimaTech.Notification.Enum;

namespace ManimaTech.Notification.Services.Message
{
    public class MessageService : IMessageService
    {
        private readonly IMessageCollection _messageCollection;
        
        public MessageService(IMessageCollection messageCollection) 
        { 
            _messageCollection = messageCollection;
        }

        public async Task<MessageModel> GetById(string id)
        {
            return await Task.FromResult(_messageCollection.GetById(id));
        }

        public async Task<MessageModel> UpdateStatus(string id, MessageStatusType status)
        {
            return await _messageCollection.UpdateStatus(id, status.ToString());
        }

        public async Task<MessageModel> UpdateStatusWithResult(string id, MessageStatusType status, string result)
        {
            return await _messageCollection.UpdateStatusWithResult(id, status.ToString(), result);
        }
    }
}
