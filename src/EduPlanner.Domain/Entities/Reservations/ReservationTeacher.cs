using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Entities.Teachers;

namespace EduPlanner.Domain.Entities.Reservations;

[Table("reser_cond")]
public class ReservationTeacher
{
    [Column("id_cond")]
    public int? TeacherId { get; set; }
    
    [Column("id")]
    public int? ReservationId { get; set; }
    
}