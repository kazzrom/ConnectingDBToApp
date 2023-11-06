using System;
using System.Collections.Generic;

namespace ConnectingDBToApp.Models;

public partial class TestResult
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public double Percentages { get; set; }
}
