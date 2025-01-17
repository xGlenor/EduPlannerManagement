using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Rooms;

[Table("rooms")]
public class Room : IEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nr_room")]
    public string? NrRoom { get; set; }
    [Column("type")]
    public string? Type { get; set; }
    [Column("comment")]
    public string? Comment { get; set; }
    [Column("capacity")]
    public short? Capacity { get; set; }
    [Column("capacity_lab")]
    public short? CapacityLab { get; set; }
    
    [Column("id_room_tree")]
    public int? RoomTreeId { get; set; }
    //public RoomTree? RoomTree { get; set; }
    
    //public ICollection<ReservationRoom>? ReservationRoom { get; set; }
    
}