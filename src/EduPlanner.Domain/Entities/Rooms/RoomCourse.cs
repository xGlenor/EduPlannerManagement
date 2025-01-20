using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Rooms;

[Table("set_rooms")]
public class RoomCourse
{
    [Column("id_room")]
    public int RoomId { get; set; }
    
    [Column("id")]
    public int CourseId { get; set; }
    
}