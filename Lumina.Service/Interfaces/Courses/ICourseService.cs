using Lumina.Service.DTOs.Courses;
using Lumina.Service.Configurations;

namespace Lumina.Service.Interfaces.Courses;
public interface ICourseService
{
    Task<bool> RemoveAsync(long id);
    Task<CourseViewModel> RetrieveByIdAsync(long id);
    Task<IEnumerable<CourseViewModel>> RetrieveAllAsync(PaginationParams @params);
    Task<CourseViewModel> AddAsync(CoursePostModel dto);
    Task<CourseViewModel> RetrieveByEmailAsync(string email);
    Task<CourseViewModel> ModifyAsync(long id, CoursePutModel dto);
}
