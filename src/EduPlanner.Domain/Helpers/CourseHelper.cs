namespace EduPlanner.Domain.Helpers;

public static class CourseHelper
{
    public static DateTime SetTime(DateTime date, TimeSpan time)
    {
        return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
    }
}