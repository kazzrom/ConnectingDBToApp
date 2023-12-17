namespace ConnectingDBToApp.Models;

public partial class TestResult
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int CountRightAnswer { get; set; }

    public int CountQuestions { get; set; }

    public double Percentages { get; set; }
}
