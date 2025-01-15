
using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Weeks;

namespace EduPlanner.Domain.Entities.Courses;

[Table("times")]
public class CourseTime
{
    [Column("idEvent")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    [Column("idWeek")]
    public int WeekId { get; set; }
    public Week Week { get; set; }
    
    [Column("idWeekDef")]
    public int WeekTypeId { get; set; }
    public WeekType WeekType { get; set; }
    
    [Column("idRoom")]
    public int RoomId { get; set; }
    public Room Room { get; set; }
    
    [Column("dtStart")]
    public DateTime? StartDate { get; set; }
    [Column("dtStop")]
    public DateTime? EndDate { get; set; }
    
    
}