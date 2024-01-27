using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class Book:Auditable
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string File { get; set; }

    public long SubjectId { get; set; }  // Foreign key
    public Subject Subject { get; set; } // Navigation property
}
