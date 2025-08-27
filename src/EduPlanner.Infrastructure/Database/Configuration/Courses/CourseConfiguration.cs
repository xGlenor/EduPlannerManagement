using EduPlanner.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Courses;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(c => c.Shortcut).HasColumnName("shortcut").HasMaxLength(255);
        builder.Property(c => c.TypeCourse).HasColumnName("type").HasMaxLength(255);
        builder.Property(c => c.Comment).HasColumnName("comment").HasDefaultValue(null);
    }
}