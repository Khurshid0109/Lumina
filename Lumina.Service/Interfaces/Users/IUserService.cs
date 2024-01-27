using Lumina.Service.DTOs.Users;
using Lumina.Service.Configurations;

namespace Lumina.Service.Interfaces.Users;
public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserViewModel> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserViewModel>> RetrieveAllAsync(PaginationParams @params);
    Task<UserViewModel> AddAsync(UserPostModel dto);
    Task<UserViewModel> RetrieveByEmailAsync(string email);
    Task<UserViewModel> ModifyAsync(long id, UserPutModel dto);
}
