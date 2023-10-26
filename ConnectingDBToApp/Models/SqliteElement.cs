using System;
using System.Collections.Generic;

namespace ConnectingDBToApp.Models;

public partial class SqliteElement
{
    public long Id { get; set; }

    public string ObjectType { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string? Code { get; set; }

    public string? AdditionalText { get; set; }
}
