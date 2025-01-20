using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.WeekTypes;

namespace EduPlanner.API.Endpoints;

public static class WeekTypesEndpointExtensions
{
    public static IEndpointRouteBuilder MapWeekTypes(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("weektypes");

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<WeekTypeDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeekTypes();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        
        return endpoints;
    }
}