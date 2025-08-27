using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

public class GroupTree: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool ShowPlan { get; set; }
    public int ParentId { get; set; }
    
    public ICollection<Group> Groups { get; set; } = new List<Group>();
}