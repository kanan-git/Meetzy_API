using Microsoft.EntityFrameworkCore;

using Core.DAL.Repositories.Abstract;
using System.Linq.Expressions;

namespace Core.DAL.Repositories.Concrete.EFCore;

public class EFCBaseRepository<TEntity, TContext>:IBaseRepository<TEntity>
    where TEntity : class, new()
    where TContext : DbContext
{
    // DI
    private readonly TContext _context;
    public EFCBaseRepository(TContext context)
    {
        _context = context;
    }


    // HttpGet
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        foreach(var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        query = GetQuery(includes);

        return filter == null 
            ? await query.ToListAsync() 
            : await query.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllWithPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        foreach(var include in includes)
        {
            query = query.Include(include);
        }

        return filter == null 
            ? await query.Skip((page-1) * size).Take(size).ToListAsync() 
            : await query.Skip((page-1) * size).Take(size).Where(filter).ToListAsync();
    }

    // HttpPost
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    // HttpPut
    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    // HttpDelete
    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    // SaveChanges
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    // Misc
    public Task<bool> IsExistEntity(Expression<Func<TEntity,bool>> filter)
    {
        return _context.Set<TEntity>().AnyAsync(filter);
    }
    public IQueryable<TEntity> GetQuery(string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        foreach(var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }
}
