using MediatR;

namespace EduPlanner.Application.WeekTypes;

public record GetWeekTypes() : IRequest<IEnumerable<WeekTypeDTO>>;