using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;

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
        modelBuilder.Entity<GroupCourse>()
            .HasKey(cg => new { cg.GroupId, cg.CourseId });
        
        modelBuilder.Entity<CourseTime>()
            .HasKey(ct => new { ct.CourseId, ct.WeekId, ct.WeekTypeId });
        
        modelBuilder.Entity<RoomCourse>()
            .HasKey(ct => new { ct.CourseId, ct.RoomId });
        
        modelBuilder.Entity<TeacherCourse>()
            .HasKey(ct => new { ct.CourseId, ct.TeacherId });
        
        modelBuilder.Entity<WeekWeekType>()
            .HasKey(ct => new { ct.WeekId, ct.WeekTypeId });

        modelBuilder.Entity<ReservationGroup>()
            .HasKey(ct => new { ct.GroupId, ct.ReservationId });
        
        modelBuilder.Entity<ReservationRoom>()
            .HasKey(ct => new { ct.RoomId, ct.ReservationId });
        
        modelBuilder.Entity<ReservationTeacher>()
            .HasKey(ct => new { ct.TeacherId, ct.ReservationId });
        
        
        base.OnModelCreating(modelBuilder);
    }
    
}