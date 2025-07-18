using EduPlanner.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class GroupCourseConfiguration : IEntityTypeConfiguration<GroupCourse>
{
    public void Configure(EntityTypeBuilder<GroupCourse> builder)
    {
        builder.ToTable("set_groups");
        
        builder.HasKey(x => new { x.GroupId, x.CourseId });
        
        builder.Property(x => x.GroupId).HasColumnName("id_group");
        builder.Property(x => x.CourseId).HasColumnName("id");
    }
}