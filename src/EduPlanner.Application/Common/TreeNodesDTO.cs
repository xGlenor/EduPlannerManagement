namespace EduPlanner.Application.Common;

public record TreeNodesDTO<T>(IEnumerable<TreeNodeDTO<T>> nodes);