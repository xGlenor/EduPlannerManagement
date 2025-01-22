using MediatR;

namespace EduPlanner.Application.Weeks;

public record GetWeekForId(int idWeek) : IRequest<WeekDTO?>;