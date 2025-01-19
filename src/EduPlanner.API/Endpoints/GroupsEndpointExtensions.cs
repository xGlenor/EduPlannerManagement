using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Common;
using EduPlanner.Application.Groups;
using EduPlanner.Application.Tree;

namespace EduPlanner.API.Endpoints;

public static class GroupsEndpointExtensions
{
    public static IEndpointRouteBuilder MapGroups(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("groups");

        group.MapGet("tree", [ProducesResponseType(typeof(TreeNodesDTO<GroupDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroupTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(GroupTimesDTO), StatusCodes.Status200OK)] async (int groupId, int weekId, int weekTypeId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetGroupTimes(groupId, weekId, weekTypeId);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
        
        return endpoints;
    }
}