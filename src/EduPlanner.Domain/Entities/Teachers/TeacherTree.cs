using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Teachers;

public class TeacherTree : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    public bool? ShowPlan { get; set; }
}