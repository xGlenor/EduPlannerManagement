using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class WeekTypeConfiguration : IEntityTypeConfiguration<WeekType>
{
    public void Configure(EntityTypeBuilder<WeekType> builder)
    {
        builder.ToTable("weekdefs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("idWeekDef");
        builder.Property(x => x.Shortcut).HasColumnName("sShortcut");
        builder.Property(x => x.Description).HasColumnName("sDescript");
        builder.Property(x => x.Show).HasColumnName("bShow");
    }
}