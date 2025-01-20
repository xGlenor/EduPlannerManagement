using System.Reflection;
using EduPlanner.Application.Common.Persistence;
using EduPlanner.AtsDbConverter.Views;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Domain.Helpers;
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

        
        Transfer<Course>(_OldDbContext.Courses.ToList());
        Transfer<ReservationType>(_OldDbContext.ReservationTypes.ToList());
        Transfer<GroupTree>(_OldDbContext.GroupTrees.ToList());
        Transfer<RoomTree>(_OldDbContext.RoomTrees.ToList());
        Transfer<TeacherTree>(_OldDbContext.TeacherTrees.ToList());
        Transfer<Reservation>(_OldDbContext.Reservations.ToList());

        Transfer<Week>(_OldDbContext.Weeks.ToList());
        Transfer<WeekType>(_OldDbContext.WeekTypes.ToList());
        Transfer<WeekWeekType>(_OldDbContext.WeekWeekTypes.ToList());
        Transfer<Room>(_OldDbContext.Rooms.ToList());
        Transfer<RoomCourse>(_OldDbContext.RoomCourses.ToList());
        Transfer<Teacher>(_OldDbContext.Teachers.ToList());
        Transfer<TeacherCourse>(_OldDbContext.TeacherCourses.ToList());
        Transfer<ReservationRoom>(_OldDbContext.ReservationRooms.ToList());
        Transfer<ReservationTeacher>(_OldDbContext.ReservationTeachers.ToList());
        Transfer<Group>(_OldDbContext.Groups.ToList());
        Transfer<GroupCourse>(_OldDbContext.GroupCourses.ToList());
        Transfer<ReservationGroup>(_OldDbContext.ReservationGroups.ToList());
        
        TransferCourseTimeTable();


    }

    public void Transfer<T>(List<T> list) where T : class
    {
        _converterView.AddItem($"Rozpoczynam transfer dla '{typeof(T).Name}'");
        _newDbContext.AddRangeAsync(list);
        _converterView.AddItem($"   -> Znaleziono {list.Count} rekordów w starej bazie");
        _converterView.AddItem($"   -> Dodano {_newDbContext.SaveChanges()} rekordów do nowej bazy");
        _converterView.AddItem($"");
    }

    public void TransferCourseTimeTable()
    {
        _converterView.AddItem($"Rozpoczynam transfer dla times");
        var timeOlds = _OldDbContext.Set<TimeOld>().ToList();
        var weeks = _OldDbContext.Set<Week>().ToList();
        var weekWeekTypes = _OldDbContext.Set<WeekWeekType>().ToList();

        var coursesList = new List<CourseTime>();
        
        foreach (var timeold in timeOlds)
        {
            DateTime? baseDate = null;
            var courseTime = new CourseTime()
            {
                CourseId = timeold.CourseId,
                WeekId = timeold.WeekId,
                WeekTypeId = timeold.WeekTypeId,
                RoomId = timeold.RoomId,
            };
            
            if (timeold.WeekId != 0)
            {
                //Dodać tylko minuty
                baseDate = weeks.FirstOrDefault(w => w.Id == timeold.WeekId)?.StartWeek;
            }else if (timeold.WeekTypeId != 0)
            {
                var weekIds = weekWeekTypes
                    .Where(w => w.WeekTypeId == timeold.WeekTypeId)
                    .Select(w => w.WeekId)
                    .ToList();

                baseDate = weeks.FirstOrDefault(w => weekIds.Contains(w.Id))?.StartWeek;
            }

            if (baseDate.HasValue)
            {
                var minutesStart = (timeold.Start - 1) * 15;
                var minutesEnd = minutesStart + (timeold.Dur * 15);
                
                var startDate = baseDate.Value.AddMinutes(minutesStart);
                var endDate = startDate.AddMinutes((timeold.Dur * 15));
                
                
                courseTime.StartDate = startDate;
                courseTime.EndDate = endDate;
                courseTime.MinutesStart = minutesStart;
                courseTime.MinutesEnd = minutesEnd;
                
                if(timeold.StartDate != TimeSpan.Zero)
                    courseTime.StartDate = CourseHelper.SetTime(courseTime.StartDate.Value, timeold.StartDate.Value);
                
                if(timeold.EndDate != TimeSpan.Zero)
                    courseTime.EndDate = CourseHelper.SetTime(courseTime.EndDate.Value, timeold.EndDate.Value);
                
                coursesList.Add(courseTime);
                
            }
        }
        
        _newDbContext.AddRangeAsync(coursesList);
        _converterView.AddItem($"   -> Znaleziono {coursesList.Count} rekordów w starej bazie");
        _converterView.AddItem($"   -> Dodano {_newDbContext.SaveChanges()} rekordów do nowej bazy");
        _converterView.AddItem($"");
        
    }
    
}