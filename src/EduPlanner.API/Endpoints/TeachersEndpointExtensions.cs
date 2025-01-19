using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Common;
using EduPlanner.Application.Teachers;
using EduPlanner.Application.Tree;

namespace EduPlanner.API.Endpoints;

public static class TeachersEndpointExtensions
{
    public static IEndpointRouteBuilder MapTeachers(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("teachers");
        
        group.MapGet("tree", [ProducesResponseType(typeof(TreeNodesDTO<TeacherDTO>), StatusCodes.Status200OK)] async (int parentId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetTeacherTreeNodes(parentId);
            var nodes = await sender.Send(query, cancellationToken);
            return Results.Ok(nodes);
        });
        
        group.MapGet("times", [ProducesResponseType(typeof(TeacherTimesDTO), StatusCodes.Status200OK)] async (int teacherId, int weekId, int weekTypeId, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetTeacherTimes(teacherId, weekId, weekTypeId);
            var courseTimes = await sender.Send(query, cancellationToken);
            return Results.Ok(courseTimes);
        });
        return endpoints;
    }
}