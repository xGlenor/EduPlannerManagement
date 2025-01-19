using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Rooms;
using EduPlanner.Application.Common;
using EduPlanner.Application.Tree;

namespace EduPlanner.API.Endpoints;

public static class RoomsEndpointExtensions
{
    public static IEndpointRouteBuilder MapRooms(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("rooms");
        
        group.MapGet("tree", [ProducesResponseType(typeof(TreeNodesDTO<RoomDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetRoomTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(RoomTimesDTO), StatusCodes.Status200OK)] async (int roomId, int weekId, int weekTypeId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetRoomTimes(roomId, weekId, weekTypeId);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
        
        return endpoints;
    }
}