using EduPlanner.Domain.Entities;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class Course: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string shortcut { get; set; }
    public string TypeCourse { get; set; }
    public string Comment { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public ICollection<GroupCourse>? GroupCourse { get; set; }
    public ICollection<TeacherCourse>? TeacherCourse { get; set; }
    public ICollection<RoomCourse>? RoomCourse { get; set; }
}