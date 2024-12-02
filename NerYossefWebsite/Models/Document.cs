using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public int PersonId { get; set; }

    public int DocumentTypeId { get; set; }

    public string DocumentPath { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public DateOnly? UploadedAt { get; set; }

    public bool IsLast { get; set; }

    public bool IsActive { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
