using EduPlanner.Domain.Entities.Weeks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class WeekConfiguration : IEntityTypeConfiguration<Week>
{
    public void Configure(EntityTypeBuilder<Week> builder)
    {
        builder.ToTable("weeks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("idWeek");
        builder.Property(x => x.StartWeek).HasColumnName("dtStart");
        builder.Property(x => x.Description).HasColumnName("sDescript").HasMaxLength(250);
    }
}