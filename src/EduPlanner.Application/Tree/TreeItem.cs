namespace EduPlanner.Application.Tree;

public sealed record TreeItem(int Id, string Name, bool IsPlanAvailable, int? ParentId);