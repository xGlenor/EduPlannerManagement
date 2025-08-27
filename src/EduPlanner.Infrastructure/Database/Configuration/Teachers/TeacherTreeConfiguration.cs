using EduPlanner.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Teachers;

internal sealed class TeacherTreeConfiguration : IEntityTypeConfiguration<TeacherTree>
{
    public void Configure(EntityTypeBuilder<TeacherTree> builder)
    {
        builder.ToTable("cond_tree");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id_cond_tree");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(x => x.ParentId).HasColumnName("parent");
        builder.Property(x => x.ShowPlan).HasColumnName("bShowPlan");
    }
}