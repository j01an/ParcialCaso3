using System;
using System.Collections.Generic;

namespace ParcialCaso3.DOMAIN.Core.Entities;

public partial class Team
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Country { get; set; }
}
