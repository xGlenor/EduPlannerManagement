namespace EduPlanner.Application.Groups;

public sealed record GroupTreeDto(
    int IdGroupTree,
    string Name,
    List<GroupTreeDto> Children,
    List<GroupDTO> Groups
);