using EduPlanner.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Groups;

internal sealed class GroupCourseConfiguration : IEntityTypeConfiguration<GroupCourse>
{
    public void Configure(EntityTypeBuilder<GroupCourse> builder)
    {
        builder.ToTable("set_groups");
        
        builder.HasNoKey();
        
        builder.Property(x => x.CourseId).HasColumnName("id");
        builder.Property(x => x.GroupId).HasColumnName("id_group");
        
        builder.HasOne(x => x.Course)
            .WithMany()
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_groups_courses");

        builder.HasOne(x => x.Group)
            .WithMany()
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_groups_groups");
    }
}