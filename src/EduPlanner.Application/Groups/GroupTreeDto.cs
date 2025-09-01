namespace EduPlanner.Application.Groups;

public sealed record GroupTreeDto(
    int Id,
    string Name,
    bool IsPlanAvailable,
    List<GroupTreeDto> Children,
    List<GroupDTO> Groups
);