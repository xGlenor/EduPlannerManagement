using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

[Table("groups")]
public class Group: IEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("shortcut")]
    public string? Shortcut { get; set; }
    [Column("semester")]
    public int? Semester { get; set; }
    [Column("comment")]
    public string? Comment { get; set; }
    [Column("nr_stud")]
    public int? NrStud { get; set; }

    [Column("id_group_tree")]
    public int? GroupTreeId { get; set; }
    public GroupTree? GroupTree { get; set; } //todo
    
}