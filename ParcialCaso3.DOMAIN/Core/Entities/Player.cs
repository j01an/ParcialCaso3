using System;
using System.Collections.Generic;

namespace ParcialCaso3.DOMAIN.Core.Entities;

public partial class Player
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? DateOfBirth { get; set; }

    public int? Dorsal { get; set; }
}
