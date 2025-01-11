using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class Teacher: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surface { get; set; }
    public string? Shortcut { get; set; }
    public string? Title { get; set; }
    public string? Room { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    
    public ICollection<TeacherCourse>? TeacherCourse { get; set; }
}
