namespace ConnectingDBToApp.Models;

public partial class SQLiteElement : ElementItem
{
    public long Id { get; set; }

    public string ObjectType { get; set; } = null!;

    public string Chapter { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string? AdditionalText { get; set; }

    public string? Code { get; set; }
}
