using Lumina.Domain.Enums;
using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class User:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool IsVerified { get; set; } = false;
    public Role Role { get; set; }
    public string Image { get; set; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireDate { get; set; }

    public ICollection<UserCourse> UserCourses { get; set; }
}