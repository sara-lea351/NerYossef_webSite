using System.Text.Json.Serialization;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.NewFolder
{
    public class studentDTO:personDTO
    {
        public int StudentId { get; set; }

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
    }
}
