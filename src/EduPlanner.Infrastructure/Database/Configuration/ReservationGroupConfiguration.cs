using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class ReservationGroupConfiguration : IEntityTypeConfiguration<ReservationGroup>
{
    public void Configure(EntityTypeBuilder<ReservationGroup> builder)
    {
        builder.ToTable("reser_group");

        builder.HasKey(ct => new { ct.GroupId, ct.ReservationId });
        
        builder.Property(x => x.GroupId).HasColumnName("id_group");
        builder.Property(x => x.ReservationId).HasColumnName("id");
    }
}