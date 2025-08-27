using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Reservations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("resers");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ReservationTypeId).HasColumnName("idReserType");
        builder.Property(x => x.Type).HasColumnName("type").HasMaxLength(255);
        builder.Property(x => x.Description).HasColumnName("descript").HasMaxLength(255);
        builder.Property(x => x.Active).HasColumnName("active");
        
        builder.HasOne(x => x.ReservationType)
            .WithMany()
            .HasForeignKey(e => e.ReservationTypeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_resers_reser_type");
    }
}