using EduPlanner.Domain.Entities.Teachers;

namespace EduPlanner.Domain.Entities.Reservations;

public class ReservationTeacher
{
    public int? ReservationId { get; set; }
    public int? TeacherId { get; set; }
    
    public virtual Teacher? Teacher { get; set; }
    public virtual Reservation? Reservation { get; set; }
}