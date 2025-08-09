using EduPlanner.Domain.Entities.Rooms;

namespace EduPlanner.Domain.Entities.Reservations;

public class ReservationRoom
{
    public int? ReservationId { get; set; }
    public int? RoomId { get; set; }
    
    public virtual Reservation? Reservation { get; set; }
    public virtual Room? Room { get; set; }
}