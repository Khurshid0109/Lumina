using Microsoft.AspNetCore.Http;

namespace Lumina.Service.DTOs.Subjects;
public record SubjectViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
}
