using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int PersonId { get; set; }

    public DateOnly BirthDate { get; set; }

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public string FatherPhone { get; set; } = null!;

    public string MotherPhone { get; set; } = null!;

    public string FatherMail { get; set; } = null!;

    public string MotherMail { get; set; } = null!;

    public string Payment { get; set; } = null!;

    public DateOnly PaymentExpiryDate { get; set; }

    public bool IsPaymentValid { get; set; }

    public string Class { get; set; } = null!;

    public DateOnly EntryDate { get; set; }

    public DateOnly? ExitDate { get; set; }

    public virtual Person Person { get; set; } = null!;
}
