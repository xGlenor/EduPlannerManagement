

using EduPlanner.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Shortcut).HasColumnName("shortcut");
        builder.Property(x => x.Semester).HasColumnName("semester");
        builder.Property(x => x.Comment).HasColumnName("nr_comment");
        builder.Property(x => x.NrStud).HasColumnName("nr_stud");
        builder.Property(x => x.GroupTreeId).HasColumnName("id_group_tree");
        
    }
}