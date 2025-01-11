using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class TeacherTree: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    public int? ParentId { get; set; }
    public TeacherTree Parent { get; set; }
    public ICollection<TeacherTree> Children { get; set; }
    
    public ICollection<Teacher> Teachers { get; set; }
    
}