using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Tree;
using EduPlanner.Application.Groups;
using EduPlanner.Infrastructure.Database.Handlers.Groups;

namespace EduPlanner.API.Endpoints;

public sealed class GroupsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("groups").WithTags("Groups");

        group.MapGet("/search", [ProducesResponseType(typeof(IEnumerable<GroupDTO>), StatusCodes.Status200OK)] async (string name, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroups(name);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
        
        
        group.MapGet("tree/{parentId}", [ProducesResponseType(typeof(TreeNodesDTO<GroupDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroupTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(GroupTimesDTO), StatusCodes.Status200OK)] async (int groupId, int weekId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroupTimes(groupId, weekId);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
        
        group.MapGet("tree", [ProducesResponseType(typeof(GroupTimesDTO), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroupTree();
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
    }
}