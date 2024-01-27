using Lumina.Domain.Commons;
using Lumina.Data.DbContexts;
using System.Linq.Expressions;
using Lumina.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Data.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    protected readonly DataContext dbContext;
    protected readonly DbSet<TEntity> dbSet;
    public Repository(DataContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression, bool deleted = false)
    {
        var entity = await this.SelectAsync(expression, deleted: deleted);

        if (entity is null)
            return false;
        if (deleted)
            dbSet.Remove(entity);
        else
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    => (await this.dbSet.AddAsync(entity)).Entity;

    public async Task SaveAsync()
      => await this.dbContext.SaveChangesAsync();

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool deleted = false)
    {
        IQueryable<TEntity> query = deleted ? dbSet.IgnoreQueryFilters() : this.dbSet;
        if (expression is not null)
            query = query.Where(expression);

        if (includes is not null)
            foreach (string include in includes)
            {
                query = query.Include(include);
            }

        return query;
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, bool deleted = false)
    => await this.SelectAll(expression, includes, deleted).FirstOrDefaultAsync();

    public async Task<TEntity> Update(TEntity entity, bool deleted = false)
    {
        var entry = this.dbContext.Update(entity);
        return entry.Entity;
    }
}
