using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class Group: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shortcut { get; set; }
    public int? Semester { get; set; }
    public string? Comment { get; set; }
    
    public int? GroupTreeId { get; set; }
    public GroupTree? GroupTree { get; set; } //todo
    
    public ICollection<GroupCourse>? GroupCourse { get; set; }
}