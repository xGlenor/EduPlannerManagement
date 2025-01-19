using EduPlanner.Application.Colors;
using EduPlanner.Application.Weeks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPlanner.API.Endpoints;

public static class WeeksEndpointExtensions
{
    public static IEndpointRouteBuilder MapWeeks(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("weeks");

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<WeekDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeeks();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        
        return endpoints;
    }
}