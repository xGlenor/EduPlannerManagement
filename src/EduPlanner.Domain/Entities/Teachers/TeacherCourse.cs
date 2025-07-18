using System.ComponentModel.DataAnnotations.Schema;

namespace EduPlanner.Domain.Entities.Teachers;

[Table("set_cond")]
public class TeacherCourse
{
    public int TeacherId { get; set; }
    public int CourseId { get; set; }
    public string? Remarks { get; set; }
    public int? IdRoom { get; set; } 
}