using EduPlanner.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Teachers;

internal sealed class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("conductors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(255);
        builder.Property(x => x.Surname).HasColumnName("surname").HasMaxLength(255);
        builder.Property(x => x.Shortcut).HasColumnName("shortcut").HasMaxLength(255);
        builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(255);
        builder.Property(x => x.Room).HasColumnName("room").HasMaxLength(255);
        builder.Property(x => x.Mail).HasColumnName("mail").HasMaxLength(255);
        builder.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(255);
        builder.Property(x => x.TeacherTreeId).HasColumnName("id_cond_tree");
        
        builder.HasOne(x => x.TeacherTree)
            .WithMany()
            .HasForeignKey(e => e.TeacherTreeId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_conductors_cond_tree");
    }
}