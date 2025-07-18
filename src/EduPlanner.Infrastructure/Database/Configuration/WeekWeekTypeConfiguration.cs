using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class WeekWeekTypeConfiguration: IEntityTypeConfiguration<WeekWeekType>
{
    public void Configure(EntityTypeBuilder<WeekWeekType> builder)
    {
        builder.ToTable("weekweekdef");

        builder.Property(x => x.WeekId).HasColumnName("idWeek");
        builder.Property(x => x.WeekTypeId).HasColumnName("idWeekDef");

        builder.HasKey(x => new { x.WeekId, x.WeekTypeId });
    }
}