using EduPlanner.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class GroupTreeConfiguration : IEntityTypeConfiguration<GroupTree>
{
    public void Configure(EntityTypeBuilder<GroupTree> builder)
    {
        builder.ToTable("group_tree");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id_group_tree");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(x => x.ShowPlan).HasColumnName("bShowPlan");
        builder.Property(x => x.ParentId).HasColumnName("parent");
    }
}