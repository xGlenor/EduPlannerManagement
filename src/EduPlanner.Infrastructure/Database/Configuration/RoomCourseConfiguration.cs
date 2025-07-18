using EduPlanner.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class RoomCourseConfiguration : IEntityTypeConfiguration<RoomCourse>
{
    public void Configure(EntityTypeBuilder<RoomCourse> builder)
    {
        builder.ToTable("set_rooms");

        builder.HasKey(ct => new { ct.CourseId, ct.RoomId });

        builder.Property(x => x.RoomId).HasColumnName("id_room");
        builder.Property(x => x.CourseId).HasColumnName("id");
    }
}