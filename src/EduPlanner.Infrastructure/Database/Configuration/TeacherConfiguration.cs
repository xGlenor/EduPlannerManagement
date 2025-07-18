using EduPlanner.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("conductors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Surname).HasColumnName("surname");
        builder.Property(x => x.Shortcut).HasColumnName("shortcut");
        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.Room).HasColumnName("room");
        builder.Property(x => x.Mail).HasColumnName("mail");
        builder.Property(x => x.Phone).HasColumnName("phone");
        builder.Property(x => x.TeacherTreeId).HasColumnName("id_cond_tree");
    }
}