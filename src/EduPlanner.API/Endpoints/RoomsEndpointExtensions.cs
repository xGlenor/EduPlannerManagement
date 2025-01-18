using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Rooms;
using EduPlanner.Application.Common;

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
        
        return endpoints;
    }
}