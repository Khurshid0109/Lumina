using Microsoft.AspNetCore.Http;

namespace Lumina.Service.DTOs.Users;
public record UserPutModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public IFormFile Image { get; set; }
}
