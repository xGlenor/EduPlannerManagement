using EduPlanner.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlanner.Infrastructure.Database.Configuration.Reservations;

public class ReservationTeacherConfiguration : IEntityTypeConfiguration<ReservationTeacher>
{
    public void Configure(EntityTypeBuilder<ReservationTeacher> builder)
    {
        builder.ToTable("reser_cond");

        builder.HasNoKey();

        builder.Property(x => x.ReservationId).HasColumnName("id");
        builder.Property(x => x.TeacherId).HasColumnName("id_cond");
        
        builder.HasOne(x => x.Reservation)
            .WithMany()
            .HasForeignKey(e => e.ReservationId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_cond_resers");
        
        builder.HasOne(x => x.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_reser_cond_conductors");
    }
}