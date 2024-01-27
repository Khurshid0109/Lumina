using Lumina.Domain.Commons;
using System.Linq.Expressions;

namespace Lumina.Data.IRepositories;
public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> Update(TEntity entity, bool deleted = false);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool deleted = false);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, bool deleted = false);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression, bool deleted = false);
    Task SaveAsync();
}
