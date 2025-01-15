using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

public class Group: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shortcut { get; set; }
    public int? Semester { get; set; }
    public string? Comment { get; set; }
    public int? NrStud { get; set; }

    public int? GroupTreeId { get; set; }
    public GroupTree? GroupTree { get; set; } //todo
    
    public ICollection<GroupCourse>? GroupCourse { get; set; }
    
    public static string OldTable = "groups";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "name",
        "semester",
        "shortcut",
        "nr_stud",
        "comment",
        "id_group_tree",
        
    };
    
}