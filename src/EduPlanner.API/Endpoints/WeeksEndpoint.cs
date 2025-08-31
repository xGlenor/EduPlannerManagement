using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduPlanner.Application.Weeks;

namespace EduPlanner.API.Endpoints;

public sealed class WeeksEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("weeks").WithTags("Weeks");;

        group.MapGet("", [ProducesResponseType(typeof(IEnumerable<WeekDTO>), StatusCodes.Status200OK)] async (CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeeks();
            var result = await sender.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        
        group.MapGet("{date:datetime}", [ProducesResponseType(typeof(WeekDTO), StatusCodes.Status200OK)] [ProducesResponseType(StatusCodes.Status404NotFound)] async (DateTime date, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeekForDate(date);
            var result = await sender.Send(query, cancellationToken);
            if (result is null)
                return Results.NotFound();
            
            return Results.Ok(result);
        });
        
        group.MapGet("{id:int}", [ProducesResponseType(typeof(WeekDTO), StatusCodes.Status200OK)] [ProducesResponseType(StatusCodes.Status404NotFound)] async (int id, CancellationToken cancellationToken, [FromServices] ISender sender) =>
        {
            var query = new GetWeekForId(id);
            var result = await sender.Send(query, cancellationToken);
            if (result is null)
                return Results.NotFound();
            
            return Results.Ok(result);
        });
    }
}