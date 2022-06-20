namespace StudentChoiceAssessment.Models;

// PART TWO
//internal class FootballRecord
//{
//    public string Team { get; set; }
//    public int GoalsFor { get; set; }
//    public int GoalsAgainst { get; set; }

//    public int GoalDifference => Math.Abs(GoalsFor - GoalsAgainst);
//}

// PART THREE
internal class FootballRecord : Record
{
    public string Team
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

    public int GoalsFor
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

    public int GoalsAgainst
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

    public override string Expression { get; } = @".*\. (\w+) +\d+ +\d+ +\d+ +\d+ +(\d+) +- +(\d+)";

    public FootballRecord() { }

    public FootballRecord(string team, string goalsFor, string goalsAgainst)
    {
        Team = team;
        GoalsFor = int.Parse(goalsFor);
        GoalsAgainst = int.Parse(goalsAgainst);
    }

    public override string ToString()
    {
        return $"{Team} had the smallest difference in 'for' and 'against' goals with {Difference}.";
    }
}