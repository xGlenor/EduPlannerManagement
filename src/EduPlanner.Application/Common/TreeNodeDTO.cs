namespace EduPlanner.Application.Common;

public record TreeNodeDTO<T>(int Id, string Name, bool? Show, IEnumerable<T> Groups);