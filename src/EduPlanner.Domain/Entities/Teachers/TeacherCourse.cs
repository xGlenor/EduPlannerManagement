using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Teachers;

public class TeacherCourse
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public string? Remarks { get; set; }
    public int? IdRoom { get; set; } 
    
    public static string OldTable = "set_cond";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "id_cond",
        "remarks",
        "idRoom",
    };
    
}