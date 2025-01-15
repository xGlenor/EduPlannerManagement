using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Teachers;

public class Teacher: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Shortcut { get; set; }
    public string? Title { get; set; }
    public string? Room { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    
    public int? TeacherTreeId { get; set; }
    //public TeacherTree? TeacherTree { get; set; }
    
    public ICollection<TeacherCourse>? TeacherCourse { get; set; }

    public static string OldTable = "conductors";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "name",
        "surname",
        "shortcut",
        "title",
        "room",
        "mail",
        "phone",
    };
}
