using System.ComponentModel.DataAnnotations.Schema;

namespace EduPlanner.Domain.Entities.Weeks;

[Table("weekweekdef")]
public class WeekWeekType
{
    [Column("idWeek")]
    public int WeekId { get; set; }

    [Column("idWeekDef")]
    public int WeekTypeId { get; set; }
    
}