using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Kollel
{
    public int KollelId { get; set; }

    public int? PersonId { get; set; }

    public string? Donor { get; set; }

    public bool IsActive { get; set; }

    public virtual Person? Person { get; set; }
}
