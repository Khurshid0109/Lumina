using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class StudyCenter:Auditable
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public float Rating { get; set; }
    public string Region { get; set; }
    public DateTime StartedDate { get; set; }
    public string ReceptionNumber { get; set; }
    public string TelegramLink { get; set; }

    public ICollection<Course> Cources { get; set; }
}
