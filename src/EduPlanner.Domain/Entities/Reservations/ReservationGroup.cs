using EduPlanner.Domain.Entities.Groups;

namespace EduPlanner.Domain.Entities.Reservations;

public class ReservationGroup
{
    public int GroupId { get; set; }
    public int ReservationId { get; set; }
    
    public virtual Group Group { get; set; } 
    public virtual Reservation Reservation { get; set; }
}