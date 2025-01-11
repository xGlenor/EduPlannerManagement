using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class GroupTree: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    public int? ParentId { get; set; }
    public GroupTree Parent { get; set; }
    public ICollection<GroupTree> Children { get; set; }
    
    public ICollection<Group> Groups { get; set; }
    
}