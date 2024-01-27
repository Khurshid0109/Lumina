namespace Lumina.Service.DTOs.Courses;
public record CoursePutModel
{
    public string CourseName { get; set; }
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
    public int AvailablePlaces { get; set; }
    public int RoomNumber { get; set; }
    public decimal Cost { get; set; }

    public long TeacherId { get; set; }
    public long? StudyCenterId { get; set; }
    public long SubjectId { get; set; }
}
