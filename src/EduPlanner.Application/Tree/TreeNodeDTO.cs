namespace EduPlanner.Application.Tree;

public record TreeNodeDTO<T>(int Id, string Name, bool? Show, IEnumerable<T> Groups, bool hasChildren);