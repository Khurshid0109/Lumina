using Lumina.Domain.Commons;

namespace Lumina.Domain.Entities;
public class Course:Auditable
{ 
    public string CourseName { get; set; }
    public float Rating { get; set; }
    public DateTime StartedDay { get; set; }
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
    public int AvailablePlaces { get; set; }
    public int RoomNumber { get; set; }
    public decimal Cost { get; set; }

    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public long? StudyCenterId { get; set; }
    public StudyCenter StudyCenter { get; set; }

    public long SubjectId { get; set; }
    public Subject Subject { get; set; }

    public ICollection<UserCourse> UserCourses { get; set; }
}
