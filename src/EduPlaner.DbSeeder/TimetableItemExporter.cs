using EduPlaner.DbSeeder.Model;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Group = EduPlaner.DbSeeder.Model.Group;
using Room = EduPlaner.DbSeeder.Model.Room;
using Week = EduPlanner.Domain.Entities.Weeks.Week;

namespace EduPlaner.DbSeeder;

internal class TimetableItemExporter
{
    private readonly NewDbContext _dbContext;

    public TimetableItemExporter(NewDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Export(TimetableItem timetableItem)
    {
        var exportedCourseId = await ExportCourse(timetableItem);
        var weekId = await ExportWeek(timetableItem);

        var room = timetableItem.ROOMS.FirstOrDefault();
        if (room is null)
            return;
        
        var existedCourseTime = await _dbContext
            .CourseTimes
            .FirstOrDefaultAsync(x=> 
                x.CourseId == exportedCourseId
                && x.StartDate == timetableItem.DTSTART
                && x.EndDate == timetableItem.DTEND
                && x.WeekId == weekId
                && x.RoomId == room.id
            );
        if (existedCourseTime is not null)
            return;
        
        var courseTime = new CourseTime
        {
            CourseId = exportedCourseId,
            StartDate = timetableItem.DTSTART,
            EndDate = timetableItem.DTEND,
            WeekId = weekId,
            RoomId = room.id
        };
        await _dbContext.CourseTimes.AddAsync(courseTime);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<int> ExportCourse(TimetableItem timetableItem)
    {
        var course = new Course
        {
            Name = timetableItem.NAME,
            TypeCourse = timetableItem.TYPE
        };
        await _dbContext.Courses.AddAsync(course);
        await _dbContext.SaveChangesAsync();

        foreach (var group in timetableItem.GROUPS)
        {
            await ExportGroup(group, course.Id);
        }
        
        foreach (var room in timetableItem.ROOMS)
        {
            await ExportRoom(room, course.Id);
        }
        
        foreach (var lecturer in timetableItem.LECTURERS)
        {
            await ExportLecturer(lecturer, course.Id);
        }
        
        return course.Id;
    }

    private async Task ExportGroup(Group group, int existedCourseId)
    {
        if (group is null)
            return;
        
        var existedGroup = _dbContext.Groups.FirstOrDefault(x => x.Id == group.id);
        if (existedGroup is null)
        {
            var newGroup = new EduPlanner.Domain.Entities.Groups.Group()
            {
                Id = group.id,
                Name = group.name
            };
            await _dbContext.Groups.AddAsync(newGroup);
            await _dbContext.SaveChangesAsync();
        }
        
        var existedGroupCourse = _dbContext
            .GroupCourses
            .FirstOrDefault(x => x.GroupId == group.id && x.CourseId == existedCourseId);
        if (existedGroupCourse is not null)
            return;

        var groupCourse = new GroupCourse()
        {
            GroupId = group.id,
            CourseId = existedCourseId
        };
        await _dbContext.GroupCourses.AddAsync(groupCourse);
        await _dbContext.SaveChangesAsync();
    }

    private async Task ExportRoom(Room room, int courseId)
    {
        if (room is null)
            return;
        
        var existedRoom = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == room.id);
        if (existedRoom is null)
        {
            var newRoom = new EduPlanner.Domain.Entities.Rooms.Room()
            {
                Id = room.id,
                NrRoom = room.name
            };
            await _dbContext.Rooms.AddAsync(newRoom);
            await _dbContext.SaveChangesAsync();
        }
        
        var existedRoomCourse = await _dbContext
            .RoomCourses
            .FirstOrDefaultAsync(x => x.CourseId == courseId && x.RoomId == room.id);
        if (existedRoomCourse is not null)
            return;

        var roomCourse = new RoomCourse
        {
            CourseId = courseId,
            RoomId = room.id
        };
        await _dbContext.RoomCourses.AddAsync(roomCourse);
        await _dbContext.SaveChangesAsync();
    }

    private async Task ExportLecturer(Lecturer lecturer, int courseId)
    {
        if (lecturer is null)
            return;
        
        var existedLecturer = await  _dbContext.Teachers.FirstOrDefaultAsync(x=>x.Id == lecturer.id);
        if (existedLecturer is null)
        {
            var teacher = new Teacher
            {
                Id = lecturer.id,
                Name = lecturer.name,
            };
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
        }
        
        var existedTeacherCourse = _dbContext
            .TeacherCourses
            .FirstOrDefault(x => x.CourseId == courseId && x.TeacherId == lecturer.id);
        if (existedTeacherCourse is not null)
            return;

        var teacherCourse = new TeacherCourse
        {
            CourseId = courseId,
            TeacherId = lecturer.id
        };
        await _dbContext.TeacherCourses.AddAsync(teacherCourse);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<int> ExportWeek(TimetableItem item)
    {
        var existedWeek = await _dbContext
            .Weeks
            .FirstOrDefaultAsync(x =>
                x.StartWeek.Value <= item.DTSTART && x.StartWeek.Value.AddDays(7) >= item.DTSTART);
        
        if (existedWeek is not null)
            return existedWeek.Id;

        var startOfWeek = item.DTSTART.StartOfWeek(DayOfWeek.Monday);
        var week = new Week
        {
            StartWeek = startOfWeek,
        };
        await _dbContext.Weeks.AddAsync(week);
        await _dbContext.SaveChangesAsync();
        
        return week.Id;
    }
}


public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
}