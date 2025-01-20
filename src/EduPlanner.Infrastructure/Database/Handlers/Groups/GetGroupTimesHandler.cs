using MediatR;
using EduPlanner.Application.Groups;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Infrastructure.Database.Handlers.Groups;

internal class GetGroupTimesHandler(NewDbContext dbContext) : GetTimesHandlerBase(dbContext), IRequestHandler<GetGroupTimes, GroupTimesDTO>
{
    public async Task<GroupTimesDTO> Handle(GetGroupTimes request, CancellationToken cancellationToken)
    {
        var times = await GetCourseTimes(request.GroupId, request.WeekId, request.WeekTypeId);
        var reservations = await GetReservations(request.GroupId, request.WeekId, request.WeekTypeId);
        
        return new GroupTimesDTO(times, reservations);
    }

    private async Task<IEnumerable<CourseTimeDTO>> GetCourseTimes(int groupId, int weekId, int weekTypeId)
    {
        var times = await (
            from courseTime in dbContext.CourseTimes
            join course in dbContext.Courses on courseTime.CourseId equals course.Id
            join groupCourse in dbContext.GroupCourses on courseTime.CourseId equals groupCourse.CourseId
            where groupCourse.GroupId == groupId 
                  && ((courseTime.WeekTypeId == 0 && courseTime.WeekId == weekId) 
                  || (courseTime.WeekId == 0 && courseTime.WeekTypeId == weekTypeId))
            select new
            {
                CourseTime = courseTime,
                Course = course,
                GroupCourse = groupCourse
            }).ToListAsync();

        return times
            .Select(x =>
                new CourseTimeDTO(
                    x.CourseTime.CourseId,
                    GetGroupsFor(x.CourseTime),
                    GetRoomsFor(x.CourseTime),
                    GetTeacherFor(x.CourseTime),
                    ToDTO(x.Course),
                    x.CourseTime.MinutesStart,
                    x.CourseTime.MinutesEnd,
                    x.CourseTime.StartDate,
                    x.CourseTime.EndDate
                )
            ).ToArray();
    }

    private async Task<IEnumerable<ReservationDTO>> GetReservations(int groupId, int weekId, int weekTypeId)
    {
        var reservations = await (
            from courseTime in dbContext.CourseTimes
            join reservation in dbContext.Reservations on courseTime.CourseId equals reservation.Id
            join reservationGroup in dbContext.ReservationGroups on reservation.Id equals reservationGroup.ReservationId
            where reservationGroup.GroupId == groupId 
                  && ((courseTime.WeekTypeId == 0 && courseTime.WeekId == weekId) 
                      || (courseTime.WeekId == 0 && courseTime.WeekTypeId == weekTypeId))
            select new
            {
                CourseTime = courseTime,
                Reservation = reservation,
                ReservationGroup = reservationGroup
            }).ToListAsync();

        return reservations
            .Select(x =>
                new ReservationDTO(
                    x.Reservation.Id,
                    x.Reservation.Description,
                    x.Reservation.Type,
                    GetRoomsFor(x.Reservation),
                    GetTeacherFor(x.Reservation),
                    x.CourseTime.MinutesStart,
                    x.CourseTime.MinutesEnd,
                    x.CourseTime.StartDate,
                    x.CourseTime.EndDate
                )
            );
    }
}