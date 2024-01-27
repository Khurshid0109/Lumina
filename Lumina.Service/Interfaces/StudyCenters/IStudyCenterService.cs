using Lumina.Service.Configurations;
using Lumina.Service.DTOs.StudyCenters;

namespace Lumina.Service.Interfaces.StudyCenters;
public interface IStudyCenterService
{
    Task<bool> RemoveAsync(long id);
    Task<StudyCenterViewModel> RetrieveByIdAsync(long id);
    Task<IEnumerable<StudyCenterViewModel>> RetrieveAllAsync(PaginationParams @params);
    Task<StudyCenterViewModel> AddAsync(StudyCenterPostModel dto);
    Task<StudyCenterViewModel> ModifyAsync(long id, StudyCenterPutModel dto);
}
