using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class WeekWeekTypeConfiguration: IEntityTypeConfiguration<WeekWeekType>
{
    public void Configure(EntityTypeBuilder<WeekWeekType> builder)
    {
        builder.ToTable("weekweekdef");

        builder.HasNoKey();

        builder.Property(x => x.WeekId).HasColumnName("idWeek");
        builder.Property(x => x.WeekTypeId).HasColumnName("idWeekDef");
        
        builder.HasOne<Week>()
            .WithMany()
            .HasForeignKey(e => e.WeekId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_weekweekdef_weeks");
        
        builder.HasOne(x => x.WeekType)
            .WithMany()
            .HasForeignKey(e => e.WeekTypeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_weekweekdef_weekdefs");
    }
}