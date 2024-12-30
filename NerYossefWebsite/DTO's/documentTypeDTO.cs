using NerYossefWebsite.Models;

namespace NerYossefWebsite.DTO_s
{
    public class documentTypeDTO
    {
        public int DocumentTypeId { get; set; }

        public string Type { get; set; } = null!;

        public bool HasExpiryDate { get; set; }

        public int? ExpiryWarningPeriod { get; set; }

    }
}
