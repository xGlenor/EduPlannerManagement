
using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Weeks;

namespace EduPlanner.Domain.Entities.Courses;

[Table("times")]
public class CourseTime
{
    [Column("idEvent")]
    public int CourseId { get; set; }
    
    [Column("idWeek")]
    public int WeekId { get; set; }
    
    [Column("idWeekDef")]
    public int WeekTypeId { get; set; }
    
    [Column("idRoom")]
    public int? RoomId { get; set; }
    
    [Column("minutesStart")]
    public int MinutesStart { get; set; }
    
    [Column("minutesEnd")]
    public int MinutesEnd { get; set; }
    
    [Column("dtStart")]
    public DateTime? StartDate { get; set; }
    [Column("dtStop")]
    public DateTime? EndDate { get; set; }
    
    public override string ToString()
    {
        return $"CourseTime: [CourseId: {CourseId}, WeekId: {WeekId}, WeekTypeId: {WeekTypeId}, MinutesStart {MinutesStart}, MinutesStop = {MinutesEnd} " +
               $"RoomId: {(RoomId.HasValue ? RoomId.ToString() : "null")}, " +
               $"StartDate: {(StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}, " +
               $"EndDate: {(EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}]";
    }
    
}