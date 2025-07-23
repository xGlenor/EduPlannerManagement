using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Teachers;

[Table("set_cond")]
public class TeacherCourse
{
    public int? TeacherId { get; set; }
    public int? CourseId { get; set; }
    public string? Remarks { get; set; }
    public int? IdRoom { get; set; } 
    
    public virtual Teacher? Teacher { get; set; }
    public virtual Course? Course { get; set; }
}