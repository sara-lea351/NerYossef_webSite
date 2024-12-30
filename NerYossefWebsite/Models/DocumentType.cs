using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string Type { get; set; } = null!;

    public bool HasExpiryDate { get; set; }

    public int? ExpiryWarningPeriod { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
