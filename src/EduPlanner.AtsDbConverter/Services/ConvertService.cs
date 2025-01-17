using System.Reflection;
using EduPlanner.Application.Common.Persistence;
using EduPlanner.AtsDbConverter.Views;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Infrastructure.Database;
using EduPlanner.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.AtsDbConverter.Services;

public interface IConvertService
{
    void Convert();
}

public class ConvertService: IConvertService
{
    private readonly IServiceProvider _serviceProvider;
    private ConverterView _converterView;
    private OldDbContext _OldDbContext;
    private NewDbContext _newDbContext;
    
    
    public ConvertService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _converterView = _serviceProvider.GetService<ConverterView>();
        _newDbContext = _serviceProvider.GetService<NewDbContext>();
        
        var dbBuilder = new DbContextOptionsBuilder<OldDbContext>();
        dbBuilder.UseMySql(DynamicConnectionString.Value, ServerVersion.AutoDetect(DynamicConnectionString.Value));
        
        _OldDbContext = new OldDbContext(dbBuilder.Options);
        
    }
    
    public void Convert()
    {
        _newDbContext.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0;");
        
        Transfer<Course>(_OldDbContext.Courses.ToList());
        Transfer<ReservationType>(_OldDbContext.ReservationTypes.ToList());
        Transfer<GroupTree>(_OldDbContext.GroupTrees.ToList());
        Transfer<RoomTree>(_OldDbContext.RoomTrees.ToList());
        Transfer<TeacherTree>(_OldDbContext.TeacherTrees.ToList());
        Transfer<Reservation>(_OldDbContext.Reservations.ToList());
        Transfer<Group>(_OldDbContext.Groups.ToList());
        Transfer<GroupCourse>(_OldDbContext.GroupCourses.ToList());
        Transfer<ReservationGroup>(_OldDbContext.ReservationGroups.ToList());
        Transfer<Week>(_OldDbContext.Weeks.ToList());
        Transfer<WeekType>(_OldDbContext.WeekTypes.ToList());
        Transfer<WeekWeekType>(_OldDbContext.WeekWeekTypes.ToList());
        Transfer<Room>(_OldDbContext.Rooms.ToList());
        Transfer<RoomCourse>(_OldDbContext.RoomCourses.ToList());
        Transfer<Teacher>(_OldDbContext.Teachers.ToList());
        Transfer<TeacherCourse>(_OldDbContext.TeacherCourses.ToList());
        Transfer<ReservationRoom>(_OldDbContext.ReservationRooms.ToList());
        Transfer<ReservationTeacher>(_OldDbContext.ReservationTeachers.ToList());
        Transfer<CourseTime>(_OldDbContext.CourseTimes.ToList());
        
        
        _newDbContext.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 1;");
        
    }

    public void Transfer<T>(List<T> list) where T : class
    {
        _newDbContext.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0;");
        _converterView.AddItem($"Rozpoczynam transfer dla '{typeof(T).Name}'");
        _newDbContext.AddRangeAsync(list);
        _converterView.AddItem($"   -> Znaleziono {list.Count} rekordów w starej bazie");
        _converterView.AddItem($"   -> Dodano {_newDbContext.SaveChanges()} rekordów do nowej bazy");
        _newDbContext.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 1;");
    }
    
}