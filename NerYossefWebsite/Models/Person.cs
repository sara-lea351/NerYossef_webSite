using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? NumberId { get; set; }

    public string? PassportNumber { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PersonType { get; set; } = null!;

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Kollel> Kollels { get; set; } = new List<Kollel>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
