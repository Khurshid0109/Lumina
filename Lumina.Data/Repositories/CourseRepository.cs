using Lumina.Data.DbContexts;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;

namespace Lumina.Data.Repositories;
public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
