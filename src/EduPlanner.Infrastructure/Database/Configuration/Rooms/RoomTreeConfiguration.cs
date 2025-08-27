using EduPlanner.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Rooms;

internal sealed class RoomTreeConfiguration : IEntityTypeConfiguration<RoomTree>
{
    public void Configure(EntityTypeBuilder<RoomTree> builder)
    {
        builder.ToTable("room_tree");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id_room_tree");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(x => x.ParentId).HasColumnName("parent");
        builder.Property(x => x.ShowPlan).HasColumnName("bShowPlan");
    }
}