using Lumina.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumina.Service.DTOs.StudyCenters;
public record StudyCenterViewModel
{
    public long Id { get; set; }
    [ForeignKey(nameof(StudyCenter))]
    public long? ParentId { get; set; }
    public StudyCenter ParentStudyCenter { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public float Rating { get; set; }
    public string Region { get; set; }
    public DateTime StartedDate { get; set; }
    public string ReceptionNumber { get; set; }
    public string TelegramLink { get; set; }
}
