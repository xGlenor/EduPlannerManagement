﻿using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Groups;

[Table("set_groups")]
public class GroupCourse
{
    [Column("id_group")]
    public int GroupId { get; set; }
    
    [Column("id")]
    public int CourseId { get; set; }

    
}