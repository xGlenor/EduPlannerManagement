using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Reservations;

internal sealed class ReservationTypeConfiguration: IEntityTypeConfiguration<ReservationType>
{
    public void Configure(EntityTypeBuilder<ReservationType> builder)
    {
        builder.ToTable("reser_type");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("idReserType");
        builder.Property(x => x.Description).HasColumnName("sDescript");
    }
}