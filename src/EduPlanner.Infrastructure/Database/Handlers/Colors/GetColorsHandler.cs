using MediatR;
using EduPlanner.Application.Colors;

namespace EduPlanner.Infrastructure.Database.Handlers.Colors;

internal class GetColorsHandler(NewDbContext dbContext) : IRequestHandler<GetColors, IEnumerable<ColorDTO>>
{
    public Task<IEnumerable<ColorDTO>> Handle(GetColors request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<ColorDTO>());
    }
}