using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Groups;

namespace EduPlanner.Domain.Entities.Reservations;

[Table("reser_group")]
public class ReservationGroup
{
    [Column("id_group")]
    public int GroupId { get; set; }
    public Group Group { get; set; }
    
    [Column("id")]
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    
}