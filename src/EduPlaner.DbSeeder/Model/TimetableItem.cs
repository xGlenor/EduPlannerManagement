namespace EduPlaner.DbSeeder.Model;

public class TimetableItem
{
    public int ATH_TYPE { get; set; }
    public DateTime DTEND { get; set; }
    public DateTime DTSTART { get; set; }
    public Duration DURATION { get; set; }
    public List<Group> GROUPS { get; set; }
    public List<Lecturer> LECTURERS { get; set; }
    public string NAME { get; set; }
    public List<Room> ROOMS { get; set; }
    public string TYPE { get; set; }
    public string TZOFFSET { get; set; }
}