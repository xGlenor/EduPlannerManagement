using System.ComponentModel.DataAnnotations.Schema;

namespace EduPlanner.Domain.Entities.Courses;

[Table("times")]
public class TimeOld
{
    [Column("idEvent")]
    public int CourseId { get; set; }
    //public Course Course { get; set; }
    
    [Column("start")]
    public int Start { get; set; }
    
    [Column("dur")]
    public int Dur { get; set; }
    
    [Column("idWeek")]
    public int WeekId { get; set; }
    //public Week Week { get; set; }
    
    [Column("idWeekDef")]
    public int WeekTypeId { get; set; }
    //public WeekType WeekType { get; set; }
    
    [Column("idRoom")]
    public int? RoomId { get; set; }
    //public Room? Room { get; set; }
    
    [Column("dtStart")]
    public TimeSpan? StartDate { get; set; }
    [Column("dtStop")]
    public TimeSpan? EndDate { get; set; }
    
    
    public override string ToString()
    {
        return $"CourseTime: [CourseId: {CourseId}, WeekId: {WeekId}, WeekTypeId: {WeekTypeId} " +
               $"RoomId: {(RoomId.HasValue ? RoomId.ToString() : "null")}, " +
               $"StartDate: {(StartDate.HasValue ? StartDate.Value.ToString() : "null")}, " +
               $"EndDate: {(EndDate.HasValue ? EndDate.Value.ToString() : "null")}]";
    }
    
}