using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Courses;

[Table("courses")]
public class Course: IEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("shortcut")]
    public string? Shortcut { get; set; }
    [Column("type")]
    public string? TypeCourse { get; set; }
    [Column("comment")]
    public string? Comment { get; set; }
}
