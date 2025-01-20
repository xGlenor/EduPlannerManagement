using MediatR;

namespace EduPlanner.Application.Weeks;

public record GetWeeks() : IRequest<IEnumerable<WeekDTO>>;