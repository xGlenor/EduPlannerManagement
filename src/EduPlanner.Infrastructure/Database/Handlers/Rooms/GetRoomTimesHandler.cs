using MediatR;
using EduPlanner.Application.Rooms;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Infrastructure.Database.Handlers.Rooms;

internal class GetRoomTimesHandler(NewDbContext dbContext) : GetTimesHandlerBase(dbContext), IRequestHandler<GetRoomTimes, RoomTimesDTO>
{
    public async Task<RoomTimesDTO> Handle(GetRoomTimes request, CancellationToken cancellationToken)
    {
        var times = await GetCourseTimes(request.RoomId, request.WeekId, request.WeekTypeId);
        var reservations = await GetReservations(request.RoomId, request.WeekId, request.WeekTypeId);
        
        return new RoomTimesDTO(times, reservations);
    }

    private async Task<IEnumerable<CourseTimeDTO>> GetCourseTimes(int roomId, int weekId, int weekTypeId)
    {
        var times = await (
            from courseTime in dbContext.CourseTimes
            join course in dbContext.Courses on courseTime.CourseId equals course.Id
            join groupCourse in dbContext.GroupCourses on courseTime.CourseId equals groupCourse.CourseId
            where courseTime.RoomId == roomId 
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

    private async Task<IEnumerable<ReservationDTO>> GetReservations(int roomId, int weekId, int weekTypeId)
    {
        var reservations = await (
            from courseTime in dbContext.CourseTimes
            join reservation in dbContext.Reservations on courseTime.CourseId equals reservation.Id
            where courseTime.RoomId == roomId 
                  && ((courseTime.WeekTypeId == 0 && courseTime.WeekId == weekId) 
                      || (courseTime.WeekId == 0 && courseTime.WeekTypeId == weekTypeId))
            select new
            {
                CourseTime = courseTime,
                Reservation = reservation
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