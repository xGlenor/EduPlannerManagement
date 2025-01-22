using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Teachers;
using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Infrastructure.Database.Handlers.Teachers;

internal class GetTeacherTimesHandler(NewDbContext dbContext): GetTimesHandlerBase(dbContext),  IRequestHandler<GetTeacherTimes, TeacherTimesDTO>
{
    public async Task<TeacherTimesDTO> Handle(GetTeacherTimes request, CancellationToken cancellationToken)
    {
        var times = await GetCourseTimes(request.TeacherId, request.WeekId, request.WeekTypeId);
        var reservations = await GetReservations(request.TeacherId, request.WeekId, request.WeekTypeId);
        
        return new TeacherTimesDTO(times, reservations);
    }
    
    private async Task<IEnumerable<CourseTimeDTO>> GetCourseTimes(int teacherId, int weekId, int weekTypeId)
    {
        
        var times = await (
            from courseTime in dbContext.CourseTimes
            join course in dbContext.Courses on courseTime.CourseId equals course.Id
            join groupCourse in dbContext.GroupCourses on courseTime.CourseId equals groupCourse.CourseId
            join weeks in dbContext.Weeks on weekId equals weeks.Id
            join rooms in dbContext.RoomCourses on courseTime.CourseId equals rooms.CourseId
            join teacherCourse in dbContext.TeacherCourses on courseTime.CourseId equals teacherCourse.CourseId
            where teacherCourse.TeacherId == teacherId
                  && ((courseTime.WeekTypeId == 0 && courseTime.WeekId == weekId) 
                  || (courseTime.WeekId == 0 && courseTime.WeekTypeId == weekTypeId))
            select new
            {
                Week = weeks,
                CourseTime = courseTime,
                Course = course,
                GroupCourse = groupCourse
            }).ToListAsync();

        return times
                .DistinctBy(x => x.GroupCourse.CourseId)
            .Select(x =>
                new CourseTimeDTO(
                    x.CourseTime.CourseId,
                    GetGroupsFor(x.CourseTime),
                    GetRoomsFor(x.CourseTime),
                    GetTeacherFor(x.CourseTime),
                    ToDTO(x.Course),
                    x.CourseTime.MinutesStart,
                    x.CourseTime.MinutesEnd,
                    x.Week.StartWeek,
                    x.CourseTime.EndDate
                )
            ).ToArray();
    }

    private async Task<IEnumerable<ReservationDTO>> GetReservations(int teacherId, int weekId, int weekTypeId)
    {
        var reservations = await (
            from courseTime in dbContext.CourseTimes
            join reservation in dbContext.Reservations on courseTime.CourseId equals reservation.Id
            join reservationTeacher in dbContext.ReservationTeachers on reservation.Id equals reservationTeacher.ReservationId
            where reservationTeacher.TeacherId == teacherId 
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