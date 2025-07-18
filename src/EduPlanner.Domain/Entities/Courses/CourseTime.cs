namespace EduPlanner.Domain.Entities.Courses;

public class CourseTime
{
    public int CourseId { get; set; }
    public int WeekId { get; set; }
    public int WeekTypeId { get; set; }
    public int? RoomId { get; set; }
    public int MinutesStart { get; set; }
    public int MinutesEnd { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public override string ToString()
    {
        return $"CourseTime: [CourseId: {CourseId}, WeekId: {WeekId}, WeekTypeId: {WeekTypeId}, MinutesStart {MinutesStart}, MinutesStop = {MinutesEnd} " +
               $"RoomId: {(RoomId.HasValue ? RoomId.ToString() : "null")}, " +
               $"StartDate: {(StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}, " +
               $"EndDate: {(EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}]";
    }
    
}