using MediatR;

namespace EduPlanner.Application.Weeks;

public record GetWeekForDate(DateTime Date) : IRequest<WeekDTO?>;