using System;
using System.Collections.Generic;

namespace ConnectingDBToApp.Models;

public partial class TestQuestion
{
    public long Id { get; set; }

    public string Ouestion { get; set; } = null!;

    public string Variant1 { get; set; } = null!;

    public string Variant2 { get; set; } = null!;

    public string Variant3 { get; set; } = null!;

    public string Variant4 { get; set; } = null!;

    public long RightAnswer { get; set; }
}
