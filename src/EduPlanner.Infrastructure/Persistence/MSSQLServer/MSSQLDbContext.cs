using EduPlanner.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Persistence.MSSQLServer;

public class MSSQLDbContext: DbContext
{
    public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options)
    {
        
    }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<GroupTree> CourseTrees { get; set; }
    public DbSet<GroupCourse> GroupsCourses { get; set; }


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<GroupCourse>()
            .HasKey(cg => new { cg.GroupId, cg.CourseId });
        

    }
}