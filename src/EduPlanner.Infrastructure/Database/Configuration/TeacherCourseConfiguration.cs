using EduPlanner.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

internal sealed class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
{
    public void Configure(EntityTypeBuilder<TeacherCourse> builder)
    {
        builder.ToTable("set_cond");

        builder.HasKey(ct => new { ct.CourseId, ct.TeacherId });
        
        builder.Property(x => x.TeacherId).HasColumnName("id_cond");
        builder.Property(x => x.CourseId).HasColumnName("id");
        builder.Property(x => x.Remarks).HasColumnName("remarks");
        builder.Property(x => x.IdRoom).HasColumnName("idRoom");
    }
}