using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Rooms;

namespace EduPlanner.Domain.Entities.Reservations;

[Table("reser_room")]
public class ReservationRoom
{
    [Column("id_room")]
    public int? RoomId { get; set; }
    //public Room Room { get; set; }
    
    [Column("id")]
    public int? ReservationId { get; set; }
    //public Reservation Reservation { get; set; }
    
}