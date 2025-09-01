namespace EduPlanner.Application.Groups;

public sealed record GroupTreeItem(int Id, string Name, bool IsPlanAvailable, int? ParentId);