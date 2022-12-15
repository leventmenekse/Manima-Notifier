using ManimaTech.Notification.Domain.Base;
using ManimaTech.Notification.Domain.Collections.Interfaces;
using ManimaTech.Notification.Domain.Model.Message;
using MongoDB.Driver;

namespace ManimaTech.Notification.Domain.Collections
{
    public class MessageCollection : BaseCollection<MessageModel>, IMessageCollection
    {
        const string COLLECTION_NAME = "Message";

        public MessageCollection(IMongoClient connection) : base(connection, COLLECTION_NAME) { }

        public async Task<MessageModel> UpdateStatus(string id, string status)
        {
            FilterDefinition<MessageModel> filter = Builders<MessageModel>.Filter.Eq(x => x.Id, id);

            var model =  _collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (model == null)
                throw new InvalidOperationException("Mesaj bulunamadı");

            model.Status = status;
            model.UpdatedAt = DateTime.UtcNow;

            await _collection.FindOneAndReplaceAsync(filter, model);

            return model;
        }

        public async Task<MessageModel> UpdateStatusWithResult(string id, string status, string result)
        {
            FilterDefinition<MessageModel> filter = Builders<MessageModel>.Filter.Eq(x => x.Id, id);

            var model = _collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (model == null)
                throw new InvalidOperationException("Mesaj bulunamadı");

            model.Status = status;
            model.UpdatedAt = DateTime.UtcNow;
            model.Result = result;

            await _collection.FindOneAndReplaceAsync(filter, model);

            return model;
        }
    }
}
