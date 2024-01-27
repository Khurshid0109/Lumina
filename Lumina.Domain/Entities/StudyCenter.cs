using Lumina.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumina.Domain.Entities;
public class StudyCenter:Auditable
{
    [ForeignKey(nameof(ParentStudyCenter))]
    public long? ParentId { get; set; }
    public StudyCenter ParentStudyCenter { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public float Rating { get; set; }
    public string Region { get; set; }
    public DateTime StartedDate { get; set; }
    public string ReceptionNumber { get; set; }
    public string TelegramLink { get; set; }

    public ICollection<Course> Cources { get; set; }
}
