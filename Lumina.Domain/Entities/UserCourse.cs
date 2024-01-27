using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class UserCourse:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long CourseId { get; set; }
    public Course Course { get; set; }
}
