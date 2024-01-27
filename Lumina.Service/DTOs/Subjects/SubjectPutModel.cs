using Microsoft.AspNetCore.Http;

namespace Lumina.Service.DTOs.Subjects;
public record SubjectPutModel
{
    public string Name { get; set; }
    public IFormFile Image { get; set; }
}
