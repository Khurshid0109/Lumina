using Microsoft.AspNetCore.Http;

namespace Lumina.Service.DTOs.Subjects;
public record SubjectPostModel
{
    public string Name { get; set; }
    public IFormFile Image { get; set; }
}
