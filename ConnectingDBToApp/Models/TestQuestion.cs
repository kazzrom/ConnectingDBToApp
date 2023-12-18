namespace ConnectingDBToApp.Models;

public partial class TestQuestion
{
    public int Id { get; set; }

    // Свойство с текстом вопроса
    public string Question { get; set; } = null!;

    // Свойство с текстом первого варианта ответа
    public string Variant1 { get; set; } = null!;

    // Свойство с текстом второго варианта ответа
    public string Variant2 { get; set; } = null!;

    // Свойство с текстом третьего варианта ответа
    public string Variant3 { get; set; } = null!;

    // Свойство с текстом четвёртого варианта ответа
    public string Variant4 { get; set; } = null!;

    // Свойство с текстом правильного варианта ответа
    public string RightAnswer { get; set; } = null!;
}
