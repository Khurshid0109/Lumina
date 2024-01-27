using Lumina.Data.DbContexts;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;

namespace Lumina.Data.Repositories;
public class SubjectRepository : Repository<Subject>, ISubjectRepository
{
    public SubjectRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
