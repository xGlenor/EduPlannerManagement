using EduPlanner.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Teachers;

internal sealed class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
{
    public void Configure(EntityTypeBuilder<TeacherCourse> builder)
    {
        builder.ToTable("set_cond");

        builder.HasNoKey();
        
        builder.Property(x => x.CourseId).HasColumnName("id");
        builder.Property(x => x.TeacherId).HasColumnName("id_cond");
        builder.Property(x => x.Remarks).HasColumnName("remarks").HasMaxLength(255);
        builder.Property(x => x.IdRoom).HasColumnName("idRoom");
        
        builder.HasOne(x => x.Course)
            .WithMany()
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_cond_courses");
        
        builder.HasOne(x => x.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_set_cond_conductors");
    }
}