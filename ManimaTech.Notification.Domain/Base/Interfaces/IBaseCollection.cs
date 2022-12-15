using System.Linq.Expressions;

namespace ManimaTech.Notification.Domain.Base.Interfaces
{
    public interface IBaseCollection<TModel>
    {
        List<TModel> GetList();

        TModel GetById(string id);

        TModel Create(TModel model);

        TModel Update(string id, TModel model);

        void Delete(TModel model);

        void Delete(string id);

        IEnumerable<TModel> Filter(Expression<Func<TModel, bool>> filter);

        TModel GetFirstOrDefault(Expression<Func<TModel, bool>> filter);

        TModel GetSingleOrDefault(Expression<Func<TModel, bool>> filter);

        long Count(Expression<Func<TModel, bool>> filter);

        string GetId(Expression<Func<TModel, bool>> filter);

        string GetBsonId(Expression<Func<TModel, bool>> filter);

        Task FindOneAndReplaceAsync(Expression<Func<TModel, bool>> predicate, TModel replacement, CancellationToken cancellationToken = default);

        Task<TModel> InsertAsync(TModel model, CancellationToken cancellationToken = default);

        Task<List<TModel>> InsertManyAsync(List<TModel> models, CancellationToken cancellationToken = default);

        Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate = null, CancellationToken cancellationToken = default);

        Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);

        long GetDocumentCount();
    }
}
