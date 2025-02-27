namespace EduPlaner.DbSeeder.Model;

public class Week
{
    public int Id { get; set; }
    public IEnumerable<Day> Days { get; set; }
}