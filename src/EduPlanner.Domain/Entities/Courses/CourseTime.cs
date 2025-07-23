using EduPlanner.Domain.Entities.Weeks;

namespace EduPlanner.Domain.Entities.Courses;

public class CourseTime
{
    public int? CourseId { get; set; }
    public int? WeekId { get; set; }
    public int? WeekTypeId { get; set; }
    public int? RoomId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public virtual Week? Week { get; set; }
    public virtual WeekType? WeekType { get; set; }
}