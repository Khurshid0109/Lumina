using Lumina.Data.DbContexts;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;

namespace Lumina.Data.Repositories;
public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    public TeacherRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
