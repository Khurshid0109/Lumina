using Lumina.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumina.Service.DTOs.StudyCenters;

public record StudyCenterPutModel
{
    [ForeignKey(nameof(StudyCenter))]
    public long? ParentId { get; set; }

    public string Name { get; set; }
    public IFormFile Logo { get; set; }
    public string Region { get; set; }
    public DateTime StartedDate { get; set; }
    public string ReceptionNumber { get; set; }
    public string TelegramLink { get; set; }
}
