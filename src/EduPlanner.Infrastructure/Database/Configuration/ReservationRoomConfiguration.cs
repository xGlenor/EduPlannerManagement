using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class ReservationRoomConfiguration  : IEntityTypeConfiguration<ReservationRoom>
{
    public void Configure(EntityTypeBuilder<ReservationRoom> builder)
    {
        builder.ToTable("reser_room");

        builder.HasNoKey();
        
        builder.Property(x => x.ReservationId).HasColumnName("id");
        builder.Property(x => x.RoomId).HasColumnName("id_room");
        
        builder.HasOne(x => x.Reservation)
            .WithMany()
            .HasForeignKey(e => e.ReservationId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_room_resers");
        
        builder.HasOne(x => x.Room)
            .WithMany()
            .HasForeignKey(e => e.RoomId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_room_rooms");
    }
}