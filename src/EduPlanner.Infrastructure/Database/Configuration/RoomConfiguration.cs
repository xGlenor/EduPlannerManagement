using EduPlanner.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class RoomConfiguration: IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.NrRoom).HasColumnName("nr_room").HasMaxLength(255);
        builder.Property(x => x.Type).HasColumnName("type").HasMaxLength(255);
        builder.Property(x => x.Comment).HasColumnName("comment");
        builder.Property(x => x.Capacity).HasColumnName("capacity");
        builder.Property(x => x.CapacityLab).HasColumnName("capacity_lab");
        builder.Property(x => x.RoomTreeId).HasColumnName("id_room_tree");
        
        builder.HasOne(x => x.NrRoom)
            .WithMany()
            .HasForeignKey(e => e.RoomTreeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_rooms_room_tree");
    }
}