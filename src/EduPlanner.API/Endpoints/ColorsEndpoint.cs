using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Colors;

namespace EduPlanner.API.Endpoints;

public sealed class ColorsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("colors").WithTags("Colors");;

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<ColorDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetColors();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
    }
}