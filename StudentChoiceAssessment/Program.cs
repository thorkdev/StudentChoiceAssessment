using StudentChoiceAssessment.Models;
using System.Text.RegularExpressions;

namespace StudentChoiceAssessment
{
    internal class Program
    {
        private static readonly string weatherDataPath = @"C:\Users\thor8\Documents\weather.dat";
        private static readonly string footballDataPath = @"C:\Users\thor8\Documents\football.dat";

        static async Task Main(string[] args)
        {
            // PART ONE
            //var weatherRecords = await GetWeatherRecordsAsync(weatherDataPath);
            //var dayWithSmallestSpread = weatherRecords.OrderBy(r => r.TemeratureSpread).First();
            //Console.WriteLine($"Day {dayWithSmallestSpread.DayNumber} had the smallest spread of {dayWithSmallestSpread.TemeratureSpread} degrees.");

            // PART TWO
            //var footballRecords = await GetFootballRecordsAsync(footballDataPath);
            //var teamWithSmallestGoalDifference = footballRecords.OrderBy(r => r.GoalDifference).First();
            //Console.WriteLine($"{teamWithSmallestGoalDifference.Team} had the smallest goal difference of {teamWithSmallestGoalDifference.GoalDifference}.");

            // PART THREE

            var weatherRecords = await Parse(weatherDataPath, (i, m, s) => new WeatherRecord(i, m, s));
            DisplayRecordWithSmallestDifference(ref weatherRecords);

            var footballRecords = await Parse(footballDataPath, (i, m, s) => new FootballRecord(i, m, s));
            DisplayRecordWithSmallestDifference(ref footballRecords);
        }

        #region Part Three

        private static async Task<HashSet<T>> Parse<T>(string path, Func<string, string, string, T> output) where T : Record, new()
        {
            if (!File.Exists(path)) // if file does not exist
            {
                throw new FileNotFoundException($"File at {path} does not exist.");
            }

            var text = await File.ReadAllTextAsync(path); // read in all text

            var records = new HashSet<T>();

            var regex = new Regex(new T().Expression, RegexOptions.Compiled);

            var matchingRecords = regex.Matches(text); // get rows that match the reg pattern

            foreach (Match record in matchingRecords) // for each record
            {
                var data = output(record.Groups[1].Value, record.Groups[2].Value, record.Groups[3].Value); // parse to generic

                records.Add(data);
            }

            return records;
        }

        private static void DisplayRecordWithSmallestDifference<T>(ref HashSet<T> records) where T : Record
        {
            var recordWithSmallestDifference = records.OrderBy(r => r.Difference).First();

            Console.WriteLine(recordWithSmallestDifference.ToString());
        }

        #endregion

        #region Part One

        //private static string RemoveAllButDigits(string text)
        //{
        //    return new string(text.Where(char.IsDigit).ToArray());
        //}

        //private static string[] SplitRowIntoColumnsByWhitespace(string row)
        //{
        //    return row.Split().Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        //}

        //private static async Task<HashSet<WeatherRecord>> GetWeatherRecordsAsync(string path)
        //{
        //    if (!File.Exists(path)) // if file does not exist
        //    {
        //        throw new FileNotFoundException($"File at {path} does not exist.");
        //    }

        //    var records = new HashSet<WeatherRecord>();

        //    var lines = await File.ReadAllLinesAsync(path);

        //    foreach (var line in lines)
        //    {
        //        if (string.IsNullOrEmpty(line)) // skip empty lines
        //        {
        //            continue;
        //        }

        //        var data = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        //        if (int.TryParse(data[0], out var dayIndex)) // only parse records that start with an int
        //        {
        //            records.Add(new WeatherRecord()
        //            {
        //                DayNumber = dayIndex,
        //                MinimumTemperature = int.Parse(RemoveAllButDigits(data[2])),
        //                MaximumTemperature = int.Parse(RemoveAllButDigits(data[1]))
        //            });
        //        }
        //    }

        //    return records;
        //}

        #endregion

        #region Part Two

        //private static async Task<HashSet<FootballRecord>> GetFootballRecordsAsync(string path)
        //{
        //    if (!File.Exists(path)) // if file does not exist
        //    {
        //        throw new FileNotFoundException($"File at {path} does not exist.");
        //    }

        //    var records = new HashSet<FootballRecord>();

        //    var lines = await File.ReadAllLinesAsync(path);

        //    foreach (var line in lines)
        //    {
        //        if (string.IsNullOrEmpty(line)) // skip empty lines
        //        {
        //            continue;
        //        }

        //        var data = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        //        if (int.TryParse(RemoveAllButDigits(data[0]), out var index)) // only parse records that start with an int
        //        {
        //            records.Add(new FootballRecord()
        //            {
        //                Team = data[1],
        //                GoalsFor = int.Parse(data[6]),
        //                GoalsAgainst = int.Parse(data[8]),
        //            });
        //        }
        //    }

        //    return records;
        //}

        #endregion
    }
}