using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduPlanner.Infrastructure.Database;

public class NewDbContext: DbContext
{
    public NewDbContext(DbContextOptions<NewDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupCourse> GroupCourses { get; set; }
    public DbSet<GroupTree> GroupTrees { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomCourse> RoomCourses { get; set; }
    public DbSet<RoomTree> RoomTrees { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherCourse> TeacherCourses { get; set; }
    public DbSet<TeacherTree> TeacherTrees { get; set; }
    public DbSet<Week> Weeks { get; set; }
    public DbSet<WeekType> WeekTypes { get; set; }
    public DbSet<WeekWeekType> WeekWeekTypes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationGroup> ReservationGroups { get; set; }
    public DbSet<ReservationRoom> ReservationRooms { get; set; }
    public DbSet<ReservationTeacher> ReservationTeachers { get; set; }
    public DbSet<ReservationType> ReservationTypes { get; set; }
    public DbSet<CourseTime> CourseTimes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}