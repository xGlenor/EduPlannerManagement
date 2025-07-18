using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Reservations;

public class Reservation : IEntity
{
    public int Id { get; set; }
    public int? ReservationTypeId { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public int? Active { get; set; }
    
}