using Lumina.Data.DbContexts;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;

namespace Lumina.Data.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
