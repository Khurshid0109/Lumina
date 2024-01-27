using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class Teacher:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public float Rating { get; set; }
    public string Bio { get; set; }
    public string? Experience { get; set; }
    public string StudyArea { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAuthorizedForTeaching { get; set; } = false;

    public ICollection<Course> Courses { get; set; }
}
