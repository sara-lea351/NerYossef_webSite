using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Alert
{
    public int AlertId { get; set; }

    public int? PersonId { get; set; }

    public string AlertType { get; set; } = null!;

    public string AlertStatus { get; set; } = null!;

    public string AlertBody { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual Person? Person { get; set; }
}
