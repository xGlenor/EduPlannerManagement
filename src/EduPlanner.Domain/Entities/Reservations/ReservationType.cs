using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Reservations;

public class ReservationType: IEntity
{
    public int Id { get; set; }
    public string? Description { get; set; }
}