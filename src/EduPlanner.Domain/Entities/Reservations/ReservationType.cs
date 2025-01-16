using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Reservations;

[Table("reser_type")]
public class ReservationType: IEntity
{
    [Column("idReserType")]
    public int Id { get; set; }
    [Column("sDescript")]
    public string Description { get; set; }
    
}