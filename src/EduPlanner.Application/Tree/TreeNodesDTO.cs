namespace EduPlanner.Application.Tree;

public record TreeNodesDTO<T>(IEnumerable<TreeNodeDTO<T>> nodes);