using System;
using System.Collections.Generic;

namespace Parcial202401_20200023.Data;

public partial class Movie
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public string? ReleaseYear { get; set; }
}
