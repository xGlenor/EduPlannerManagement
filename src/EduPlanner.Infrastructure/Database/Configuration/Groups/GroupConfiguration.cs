using EduPlanner.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Groups;

internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(x => x.Shortcut).HasColumnName("shortcut").HasMaxLength(255).IsRequired();
        builder.Property(x => x.Semester).HasColumnName("semester");
        builder.Property(x => x.Comment).HasColumnName("comment").IsRequired();
        builder.Property(x => x.NrStud).HasColumnName("nr_stud");
        builder.Property(x => x.GroupTreeId).HasColumnName("id_group_tree");
        
        builder.HasOne(x => x.GroupTree)
            .WithMany(gt => gt.Groups)
            .HasForeignKey(x => x.GroupTreeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_groups_group_tree");
    }
}