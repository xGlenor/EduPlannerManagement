
using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

[Table("weekdefs")]
public class WeekType: IEntity
{
    [Column("idWeekDef")]
    public int Id { get; set; }
    [Column("sShortcut")]
    public string? Shortcut { get; set; }
    [Column("sDescript")]
    public string? Description { get; set; }
    [Column("bShow")]
    public bool? Show {get; set;}
    
    public ICollection<WeekWeekType>? WeekWeekTypes { get; set; }
    public ICollection<CourseTime>? CourseTimes { get; set; }
    

}