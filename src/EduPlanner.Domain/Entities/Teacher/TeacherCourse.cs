﻿namespace EduPlanner.Domain.Entities;

public class TeacherCourse
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public string? Remarks { get; set; }
    public int? IdRoom { get; set; } 
}