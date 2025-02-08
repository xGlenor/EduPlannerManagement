using System.Text.Json;
using EduPlaner.DbSeeder.Model;

namespace EduPlaner.DbSeeder;

internal class FilesImporter
{
    public async IAsyncEnumerable<TimetableItem> Import(string dirPath)
    {
        var files = Directory.GetFiles(dirPath);

        for (var i = 0; i < files.Length; i++)
        {
            var file = files[i];
            var json = File.ReadAllText(file);
            var timeTable = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, TimetableItem[]>>>(json);

            foreach (var days in timeTable.Values)
            {
                foreach (var day in days)
                {
                    if (day.Value.Length == 0)
                        continue;
                    foreach (var timetableItem in day.Value)
                    {
                        yield return timetableItem;
                    }
                }
            }
            
            Console.WriteLine($"[{i}/{files.Length}] Imported {file}.");
        }
    }
}