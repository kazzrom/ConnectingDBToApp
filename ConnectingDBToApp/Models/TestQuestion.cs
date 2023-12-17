namespace ConnectingDBToApp.Models;

public partial class TestQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Variant1 { get; set; } = null!;

    public string Variant2 { get; set; } = null!;

    public string Variant3 { get; set; } = null!;

    public string Variant4 { get; set; } = null!;

    public string RightAnswer { get; set; } = null!;
}
