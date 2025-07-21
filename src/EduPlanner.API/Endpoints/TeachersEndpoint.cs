using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Tree;
using EduPlanner.Application.Rooms;
using EduPlanner.Application.Teachers;

namespace EduPlanner.API.Endpoints;

public sealed class TeachersEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("teachers");
        
        group.MapGet("/search", [ProducesResponseType(typeof(IEnumerable<RoomDTO>), StatusCodes.Status200OK)] async (string name, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetTeachers(name);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("tree", [ProducesResponseType(typeof(TreeNodesDTO<TeacherDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetTeacherTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(TeacherTimesDTO), StatusCodes.Status200OK)] async (int teacherId, int weekId, int[] weekTypeIds, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetTeacherTimes(teacherId, weekId, weekTypeIds);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
    }
}