using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Reservations;

internal sealed class ReservationGroupConfiguration : IEntityTypeConfiguration<ReservationGroup>
{
    public void Configure(EntityTypeBuilder<ReservationGroup> builder)
    {
        builder.ToTable("reser_group");

        builder.HasKey(ct => new { ct.GroupId, ct.ReservationId });
        
        builder.Property(x => x.GroupId).HasColumnName("id_group");
        builder.Property(x => x.ReservationId).HasColumnName("id");
        
        builder
            .HasOne(x => x.Reservation)
            .WithMany()
            .HasForeignKey(x => x.ReservationId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_group_resers");
        
        builder.HasOne(x=> x.Group)
            .WithMany()
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_group_groups");
        
    }
}