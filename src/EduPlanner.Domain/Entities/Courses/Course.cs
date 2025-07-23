using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Courses;

public class Course : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shortcut { get; set; }
    public string? TypeCourse { get; set; }
    public string? Comment { get; set; }
}