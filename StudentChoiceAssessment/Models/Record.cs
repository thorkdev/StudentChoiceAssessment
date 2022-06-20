namespace StudentChoiceAssessment.Models;

internal class Record
{
    public string Identifier { get; set; }
    public int Minuend { get; set; }
    public int Subtrahend { get; set; }

    public virtual string Expression { get; }

    public int Difference => Math.Abs(Minuend - Subtrahend);
}
