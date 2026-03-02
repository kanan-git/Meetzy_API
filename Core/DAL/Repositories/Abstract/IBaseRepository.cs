using System.Linq.Expressions;
using Core.Entities.Abstract;

namespace Core.DAL.Repositories.Abstract;

public interface IBaseRepository<TEntity>
    where TEntity : class, new()
{
    // HttpGet
    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes);
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);
    public Task<List<TEntity>> GetAllWithPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] includes);

    // HttpPost
    public Task AddAsync(TEntity entity);

    // HttpPut
    public void Update(TEntity entity);

    // HttpDelete
    public void Remove(TEntity entity);

    // SaveChanges
    public Task<int> SaveAsync();

    // Misc
    public Task<bool> IsExistEntity(Expression<Func<TEntity,bool>> filter);
    public IQueryable<TEntity> GetQuery(string[] includes);
}
