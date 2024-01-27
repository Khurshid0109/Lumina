using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class Subject:Auditable
{
    public string Name { get; set; }
    public string Image { get; set; }

    public ICollection<Book> Books { get; set; }
    public ICollection<Course> Courses { get; set; }
}
