using EduPlanner.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).HasColumnName("id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name");
        builder.Property(c => c.Shortcut).HasColumnName("shortcut");
        builder.Property(c => c.TypeCourse).HasColumnName("type");
        builder.Property(c => c.Comment).HasColumnName("comment");
    }
}