using EduPlanner.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class CourseTimeConfiguration : IEntityTypeConfiguration<CourseTime>
{
    public void Configure(EntityTypeBuilder<CourseTime> builder)
    {
        builder.ToTable("times");
        
        builder.HasKey(ct => new { ct.CourseId, ct.WeekId, ct.WeekTypeId });

        builder.Property(c => c.CourseId).HasColumnName("idEvent").IsRequired();
        builder.Property(c => c.WeekId).HasColumnName("idWeek").IsRequired();
        builder.Property(c => c.WeekTypeId).HasColumnName("idWeekDef").IsRequired();
        builder.Property(c => c.RoomId).HasColumnName("idRoom");
        builder.Property(c => c.MinutesStart).HasColumnName("minutesStart").IsRequired();
        builder.Property(c => c.MinutesEnd).HasColumnName("minutesEnd").IsRequired();
        builder.Property(c => c.StartDate).HasColumnName("dtStart");
        builder.Property(c => c.EndDate).HasColumnName("dtStop");
    }
}