using EduPlanner.Application.Colors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPlanner.API.Endpoints;

public static class ColorsEndpointExtensions
{
    public static IEndpointRouteBuilder MapColors(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("colors");

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<ColorDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetColors();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        
        return endpoints;
    }
}