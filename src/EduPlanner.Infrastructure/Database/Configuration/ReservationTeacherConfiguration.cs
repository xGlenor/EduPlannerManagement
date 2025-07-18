using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration;

public class ReservationTeacherConfiguration : IEntityTypeConfiguration<ReservationTeacher>
{
    public void Configure(EntityTypeBuilder<ReservationTeacher> builder)
    {
        builder.ToTable("reser_cond");

        builder.Property(x => x.TeacherId).HasColumnName("id_cond");
        builder.Property(x => x.ReservationId).HasColumnName("id");
    }
}