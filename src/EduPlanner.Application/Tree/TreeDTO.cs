namespace EduPlanner.Application.Tree;

public record TreeDTO<TItems>(
    int IdTree,
    string Name,
    List<TreeDTO<TItems>> Children,
    List<TItems> Items
    );