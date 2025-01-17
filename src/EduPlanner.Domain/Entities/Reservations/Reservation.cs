using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Reservations;

[Table("resers")]
public class Reservation : IEntity
{
    [Column("id")] 
    public int Id { get; set; }

    [Column("idReserType")] 
    public int? ReservationTypeId { get; set; }
    //public ReservationType? ReservationType { get; set; }

    [Column("type")] 
    public string? Type { get; set; }

    [Column("descript")] 
    public string? Description { get; set; }

    [Column("active")] 
    public int? Active { get; set; }

    //public ICollection<ReservationGroup>? ReservationGroups { get; set; }
    //public ICollection<ReservationRoom>? ReservationRooms { get; set; }
    //public ICollection<ReservationTeacher>? ReservationTeachers { get; set; }

}