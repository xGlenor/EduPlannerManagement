using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class ReservationRoomConfiguration  : IEntityTypeConfiguration<ReservationRoom>
{
    public void Configure(EntityTypeBuilder<ReservationRoom> builder)
    {
        builder.ToTable("reser_room");
        
        builder.HasKey(ct => new { ct.RoomId, ct.ReservationId });

        builder.Property(x => x.RoomId).HasColumnName("id_room");
        builder.Property(x => x.ReservationId).HasColumnName("id");
    }
}