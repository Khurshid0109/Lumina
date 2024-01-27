using Lumina.Service.DTOs.Subjects;
using Lumina.Service.Configurations;

namespace Lumina.Service.Interfaces.Subjects;
public interface ISubjectService
{
    Task<bool> RemoveAsync(long id);
    Task<SubjectViewModel> RetrieveByIdAsync(long id);
    Task<IEnumerable<SubjectViewModel>> RetrieveAllAsync(PaginationParams @params);
    Task<SubjectViewModel> AddAsync(SubjectPostModel dto);
    Task<SubjectViewModel> ModifyAsync(long id, SubjectPutModel dto);
}
