namespace StudentChoiceAssessment.Models;

// PART ONE
//internal class WeatherRecord
//{
//    public int DayNumber { get; set; }
//    public int MaximumTemperature { get; set; }
//    public int MinimumTemperature { get; set; }

//    public int TemeratureSpread => MaximumTemperature - MinimumTemperature;
//}

// PART THREE
internal class WeatherRecord : Record
{
    public string DayNumber
    {
        get
        {
            return Identifier;
        }
        set
        {
            Identifier = value;
        }
    }

    public int MaximumTemperature
    {
        get
        {
            return Minuend;
        }
        set
        {
            Minuend = value;
        }
    }

    public int MinimumTemperature
    {
        get
        {
            return Subtrahend;
        }
        set
        {
            Subtrahend = value;
        }
    }

    public override string Expression { get; } = @".*  (\d{1,2})  (\d{1,3}) +(\d{1,3})";

    public WeatherRecord() { }

    public WeatherRecord(string dayNumber, string maximumTemperature, string minimumTemperature)
    {
        DayNumber = dayNumber;
        MaximumTemperature = int.Parse(maximumTemperature);
        MinimumTemperature = int.Parse(minimumTemperature);
    }

    public override string ToString()
    {
        return $"Day {DayNumber} had the lowest temperature spread of {Difference} degrees.";
    }
}