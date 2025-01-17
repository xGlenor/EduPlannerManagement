using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

[Table("weeks")]
public class Week: IEntity
{
    [Column("idWeek")]
    public int Id { get; set; }
    [Column("dtStart")]
    public DateTime? StartWeek { get; set; }
    [Column("sDescript")]
    public string? Description { get; set; }
    
    //public ICollection<WeekWeekType>? WeekWeekTypes { get; set; }
    //public ICollection<CourseTime>? CourseTimes { get; set; }
    
}