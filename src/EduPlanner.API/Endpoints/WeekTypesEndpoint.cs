using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.WeekTypes;

namespace EduPlanner.API.Endpoints;

public sealed class WeekTypesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("weektypes");

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<WeekTypeDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeekTypes();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
    }
}