using Lumina.Domain.Enums;
using Lumina.Domain.Entities;

namespace Lumina.Service.DTOs.Courses;
public record CourseViewModel
{
    public long Id { get; set; }
    public string CourseName { get; set; }
    public float Rating { get; set; }
    public Status Status { get; set; }
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
}
