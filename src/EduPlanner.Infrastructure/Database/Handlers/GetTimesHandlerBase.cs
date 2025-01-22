using EduPlanner.Application.Groups;
using EduPlanner.Application.Rooms;
using EduPlanner.Application.Teachers;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Application.CourseTimes;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Entities.Reservations;

namespace EduPlanner.Infrastructure.Database.Handlers;

internal abstract class GetTimesHandlerBase(NewDbContext dbContext)
{
    protected IEnumerable<GroupDTO> GetGroupsFor(CourseTime courseTime)
    {
        return dbContext
            .GroupCourses
            .Where(y => y.CourseId == courseTime.CourseId)
            .Join(
                dbContext.Groups,
                x=>x.GroupId,
                x=>x.Id,
                (x, y) => y
            )
            .AsEnumerable()
            .Select(ToDTO);
    }
    
    protected IEnumerable<GroupDTO> GetGroupsFor(Reservation reservation)
    {
        return dbContext
            .ReservationGroups
            .Where(y => y.ReservationId == reservation.Id)
            .Join(
                dbContext.Groups,
                x=>x.GroupId,
                x=>x.Id,
                (x, y) => y
            )
            .AsEnumerable()
            .Select(ToDTO);
    }
    protected IEnumerable<RoomDTO> GetRoomsFor(CourseTime courseTime)
    {
        return dbContext
            .Rooms
            .Where(y => y.Id == courseTime.RoomId)
            .AsEnumerable()
            .Select(ToDTO);
    }
    protected IEnumerable<RoomDTO> GetRoomsFor(RoomCourse roomCourse)
    {
        return dbContext
            .Rooms
            .Where(y => y.Id == roomCourse.RoomId)
            .AsEnumerable()
            .Select(ToDTO);
    }

    protected IEnumerable<RoomDTO> GetRoomsFor(Reservation reservation)
    {
        return dbContext
            .ReservationRooms
            .Where(x => x.ReservationId == reservation.Id)
            .Join(
                dbContext.Rooms,
                x=>x.RoomId,
                x=>x.Id,
                (x,y) => y
            )
            .AsEnumerable()
            .Select(ToDTO);
    }
    
    protected IEnumerable<TeacherDTO> GetTeacherFor(CourseTime courseTime)
    {
        return dbContext
            .TeacherCourses
            .Where(x => x.CourseId == courseTime.CourseId)
            .Join(
                dbContext.Teachers,
                x => x.TeacherId,
                x => x.Id,
                (x, y) => new TeacherDTO(y.Id, y.Name, y.Surname)
            ).AsEnumerable();
    }
    
    protected IEnumerable<TeacherDTO> GetTeacherFor(Reservation reservation)
    {
        return dbContext
            .ReservationTeachers
            .Where(x => x.ReservationId == reservation.Id)
            .Join(
                dbContext.Teachers,
                x => x.TeacherId,
                x => x.Id,
                (x, y) => new TeacherDTO(y.Id, y.Name, y.Surname)
            ).AsEnumerable();
    }
    
    protected GroupDTO ToDTO(Group group) => new GroupDTO(group.Id, group.Name, group.Shortcut);
    protected CourseDTO ToDTO(Course course) => new CourseDTO(course.Id, course.Name, course.Shortcut, course.TypeCourse);
    protected RoomDTO ToDTO(Room room) => new RoomDTO(room.Id, room.NrRoom, room.Type);
    protected TeacherDTO ToDTO(Teacher teacher) => new TeacherDTO(teacher.Id, teacher.Name, teacher.Surname);
}