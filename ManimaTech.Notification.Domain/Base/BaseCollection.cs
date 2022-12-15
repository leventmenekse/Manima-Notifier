using ManimaTech.Notification.Domain.Base.Interfaces;
using ManimaTech.Notification.Domain.Model.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ManimaTech.Notification.Domain.Base
{
    public abstract class BaseCollection<TModel> : IBaseCollection<TModel>
        where TModel : BaseModel
    {
        const string DB_NAME = "Notifications";

        protected readonly IMongoCollection<TModel> _collection;
        protected readonly IMongoClient _client;
        protected readonly IMongoDatabase _database;

        protected BaseCollection(IMongoClient client, string collectionName)
        {
            _client = client;
            _database = _client.GetDatabase(DB_NAME);
            _collection = _database.GetCollection<TModel>(collectionName);
        }

        public virtual List<TModel> GetList()
        {
            return _collection.Find(x => true).ToList();
        }

        public virtual TModel GetById(string id)
        {
            return _collection.Find<TModel>(m => m.Id == id).FirstOrDefault();
        }

        public virtual TModel Create(TModel model)
        {
            var existingItem = _collection.Find<TModel>(m => m.Id == model.Id).FirstOrDefault();

            if (existingItem == null)
                _collection.InsertOne(model);
            else
                _collection.ReplaceOne(m => m.Id == existingItem.Id, model);

            return model;
        }

        public virtual TModel Update(string id, TModel model)
        {
            _collection.ReplaceOne(m => m.Id == id, model);
            return model;
        }

        public virtual void Delete(TModel model)
        {
            _collection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(string id)
        {
            _collection.DeleteOne(m => m.Id == id);
        }

        public IEnumerable<TModel> Filter(Expression<Func<TModel, bool>> filter)
        {
            return _collection.Find(filter).ToList();
        }

        public TModel GetFirstOrDefault(Expression<Func<TModel, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public TModel GetSingleOrDefault(Expression<Func<TModel, bool>> filter)
        {
            return _collection.Find(filter).SingleOrDefault();
        }

        public long Count(Expression<Func<TModel, bool>> filter)
        {
            return _collection.CountDocuments(filter);
        }

        public string GetId(Expression<Func<TModel, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault()?.Id.ToString()?.ToString();
        }

        public string GetBsonId(Expression<Func<TModel, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault().Id;
        }

        public virtual void FindOneAndReplace(Expression<Func<TModel, bool>> predicate, TModel replacement, CancellationToken cancellationToken = default)
        {
            _collection.FindOneAndReplace(predicate, replacement);
        }

        public virtual async Task FindOneAndReplaceAsync(Expression<Func<TModel, bool>> predicate, TModel replacement, CancellationToken cancellationToken = default)
        {
            await _collection.FindOneAndReplaceAsync(predicate, replacement, cancellationToken: cancellationToken);
        }

        public virtual async Task<TModel> InsertAsync(TModel model, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(model, null, cancellationToken);
            return model;
        }

        public virtual async Task<List<TModel>> InsertManyAsync(List<TModel> models, CancellationToken cancellationToken = default)
        {
            await _collection.InsertManyAsync(models, cancellationToken: cancellationToken);
            return models;
        }

        public async Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            IAsyncCursor<TModel> entities;
            if (predicate != null)
                entities = await _collection.FindAsync(predicate, cancellationToken: cancellationToken);
            else
                entities = await _collection.FindAsync(_ => true, cancellationToken: cancellationToken);
            return await entities.ToListAsync(cancellationToken);
        }

        public async Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _collection.FindAsync(predicate, cancellationToken: cancellationToken);
            return await entity.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual long GetDocumentCount()
        {
            long count = _collection.CountDocuments(new BsonDocument());
            return count;
        }

        public virtual List<TModel> InsertMany(IClientSessionHandle session, List<TModel> models)
        {
            _collection.InsertMany(session, models);
            return models;
        }
    }
}
