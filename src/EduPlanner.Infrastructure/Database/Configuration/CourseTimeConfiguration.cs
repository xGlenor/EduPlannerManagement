using EduPlanner.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class CourseTimeConfiguration : IEntityTypeConfiguration<CourseTime>
{
    public void Configure(EntityTypeBuilder<CourseTime> builder)
    {
        builder.ToTable("times");

        builder.HasNoKey();

        builder.Property(c => c.CourseId).HasColumnName("idEvent").HasDefaultValue(null);
        builder.Property(c => c.WeekId).HasColumnName("idWeek").HasDefaultValue(0);
        builder.Property(c => c.WeekTypeId).HasColumnName("idWeekDef").HasDefaultValue(0);
        builder.Property(c => c.RoomId).HasColumnName("idRoom").IsRequired();
        builder.Property(c => c.StartDate).HasColumnName("dtStart").HasDefaultValue("00:00:00");
        builder.Property(c => c.EndDate).HasColumnName("dtStop").HasDefaultValue("00:00:00");

        builder
            .HasOne(x => x.Week)
            .WithMany()
            .HasForeignKey(x => x.WeekId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_times_weeks");
        
        builder
            .HasOne(x => x.WeekType)
            .WithMany()
            .HasForeignKey(x => x.WeekTypeId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_times_weekdefs");
    }
}