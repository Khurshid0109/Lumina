using Lumina.Data.DbContexts;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;

namespace Lumina.Data.Repositories;
public class StudyCenterRepository : Repository<StudyCenter>, IStudyCenterRepository
{
    public StudyCenterRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
