using EduPlanner.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Rooms;

internal sealed class RoomCourseConfiguration : IEntityTypeConfiguration<RoomCourse>
{
    public void Configure(EntityTypeBuilder<RoomCourse> builder)
    {
        builder.ToTable("set_rooms");

        builder.HasNoKey();

        builder.Property(x => x.CourseId).HasColumnName("id");
        builder.Property(x => x.RoomId).HasColumnName("id_room");
        
        builder.HasOne(x => x.Course)
            .WithMany()
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_rooms_courses");
        
        builder.HasOne(x => x.Room)
            .WithMany()
            .HasForeignKey(e => e.RoomId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_rooms_rooms");
    }
}