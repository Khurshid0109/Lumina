using Lumina.Service.Configurations;
using Lumina.Service.DTOs.Teachers;

namespace Lumina.Service.Interfaces.Teachers;
public interface ITeacherService
{
    Task<bool> RemoveAsync(long id);
    Task<TeacherViewModel> RetrieveByIdAsync(long id);
    Task<IEnumerable<TeacherViewModel>> RetrieveAllAsync(PaginationParams @params);
    Task<TeacherViewModel> AddAsync(TeacherPostModel dto);
    Task<TeacherViewModel> RetrieveByEmailAsync(string email);
    Task<TeacherViewModel> ModifyAsync(long id, TeacherPutModel dto);
}
