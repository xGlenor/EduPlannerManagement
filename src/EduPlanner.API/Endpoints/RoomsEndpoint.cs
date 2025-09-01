using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Tree;
using EduPlanner.Application.Rooms;

namespace EduPlanner.API.Endpoints;

public sealed class RoomsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("rooms").WithTags("Rooms");;
        
        group.MapGet("/search", [ProducesResponseType(typeof(IEnumerable<RoomDTO>), StatusCodes.Status200OK)] async (string name, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetRooms(name);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("tree", [ProducesResponseType(typeof(TreeNodesDTO<RoomDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetRoomTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(RoomTimesDTO), StatusCodes.Status200OK)] async (int roomId, int weekId, int[] weekTypeIds, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetRoomTimes(roomId, weekId, weekTypeIds);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
    }
}