namespace ConnectingDBToApp.Models;

public partial class TestResult
{
    public int Id { get; set; }

    // Свойство с именем пользователя, проходивший тест
    public string Username { get; set; } = null!;

    // Свойство с количеством правильных ответов
    public int CountRightAnswer { get; set; }

    // Свойство с количеством вопросов теста
    public int CountQuestions { get; set; }

    // Свойство с процентом правильных ответов
    public double Percentages { get; set; }
}
