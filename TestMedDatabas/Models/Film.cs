using System;
using System.Collections.Generic;

namespace TestMedDatabas.Models;

public partial class Film
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public int? Year { get; set; }
}
