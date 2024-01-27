using Microsoft.AspNetCore.Http;

namespace Lumina.Service.DTOs.Teachers;
public record TeacherPostModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile Image { get; set; }
    public string Bio { get; set; }
    public string? Experience { get; set; }
    public string StudyArea { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<long> StudyCenterIds { get; set; }
}
