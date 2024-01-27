using Lumina.Domain.Entities;

namespace Lumina.Service.DTOs.Teachers;
public record TeacherViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public float Rating { get; set; }
    public string Bio { get; set; }
    public string? Experience { get; set; }
    public string StudyArea { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsAuthorizedForTeaching { get; set; }
    public ICollection<StudyCenter> StudyCenters { get; set; }
}
