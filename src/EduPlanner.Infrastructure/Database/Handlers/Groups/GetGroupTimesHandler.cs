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
        var times = await GetCourseTimes(request.GroupId, request.WeekId);
        //var reservations = await GetReservations(request.GroupId, request.WeekId, request.WeekTypeIds);
        
        return new GroupTimesDTO(times, []);
    }

    private async Task<IEnumerable<CourseTimeDTO>> GetCourseTimes(int groupId, int weekId)
    {
        var weekdIds = await (
            from weekType in dbContext.WeekWeekTypes
            where weekType.WeekId == weekId
            select weekType.WeekTypeId
        ).ToListAsync();
        
        var timesnew = await (
                from course in dbContext.Courses
                join set_group in dbContext.GroupCourses on course.Id equals set_group.CourseId
                join groups in dbContext.Groups on set_group.GroupId equals groups.Id
                join time in dbContext.CourseTimes on course.Id equals time.CourseId
                join weekDef in dbContext.WeekTypes on time.WeekTypeId equals weekDef.Id
                where groups.Id == groupId 
                      && weekdIds.Contains(time.WeekTypeId)
                      && time.Start >= 225 && time.Start <= 318
                select new
                {
                    Course = course.Name,
                    CourseShortcut = course.Shortcut,
                    Group = groups.Name,
                    GroupShortcut = groups.Shortcut,
                    WeekType = weekDef.Shortcut
                } 
            ).ToListAsync();


        return null;
        // var times = await (
        //     from courseTime in dbContext.CourseTimes
        //     join course in dbContext.Courses on courseTime.CourseId equals course.Id
        //     join rooms in dbContext.RoomCourses on courseTime.CourseId equals rooms.CourseId
        //     join week in dbContext.Weeks on weekId equals week.Id
        //     join groupCourse in dbContext.GroupCourses on courseTime.CourseId equals groupCourse.CourseId
        //     where groupCourse.GroupId == groupId 
        //           && (courseTime.WeekId == weekId || weekTypeIds.Contains(courseTime.WeekTypeId.Value))
        //     select new
        //     {
        //         Week = week,
        //         RoomCourse = rooms,
        //         CourseTime = courseTime,
        //         Course = course,
        //         GroupCourse = groupCourse
        //     }).ToListAsync();
        //
        // return times
        //     .Select(x =>
        //         new CourseTimeDTO(
        //             x.CourseTime.CourseId.Value, 
        //             GetGroupsFor(x.CourseTime),
        //             GetRoomsFor(x.RoomCourse),
        //             GetTeacherFor(x.CourseTime),
        //             ToDTO(x.Course),
        //             x.CourseTime.StartDate,
        //             x.CourseTime.EndDate
        //         )
        //     ).ToArray();
    }

    private async Task<IEnumerable<ReservationDTO>> GetReservations(int groupId, int weekId, int[] weekTypeIds)
    {
        var reservations = await (
            from courseTime in dbContext.CourseTimes
            join reservation in dbContext.Reservations on courseTime.CourseId equals reservation.Id
            join reservationGroup in dbContext.ReservationGroups on reservation.Id equals reservationGroup.ReservationId
            join week in dbContext.Weeks on weekId equals week.Id
            where reservationGroup.GroupId == groupId 
                  && (courseTime.WeekId == weekId || weekTypeIds.Contains(courseTime.WeekTypeId.Value))
            select new
            {
                Week = week,
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
                    x.Week.StartWeek,
                    x.CourseTime.EndDate
                )
            );
    }
}