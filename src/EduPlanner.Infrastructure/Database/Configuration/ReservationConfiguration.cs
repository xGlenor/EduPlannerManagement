using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("resers");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ReservationTypeId).HasColumnName("idReserType");
        builder.Property(x => x.Type).HasColumnName("type");
        builder.Property(x => x.Description).HasColumnName("descript");
        builder.Property(x => x.Active).HasColumnName("active");
    }
}