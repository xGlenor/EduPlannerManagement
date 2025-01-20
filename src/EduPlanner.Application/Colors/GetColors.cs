using MediatR;

namespace EduPlanner.Application.Colors;

public record GetColors() : IRequest<IEnumerable<ColorDTO>>;