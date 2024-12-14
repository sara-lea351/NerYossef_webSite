using NerYossefWebsite.Models;

namespace NerYossefWebsite.DTO_s
{
    public class documentDTO
    {
        public int DocumentId { get; set; }

        public int PersonId { get; set; }

        public int DocumentTypeId { get; set; }

        public string DocumentPath { get; set; } = null!;

        public DateOnly? ExpiryDate { get; set; }

        public DateOnly? UploadedAt { get; set; }

        public bool? IsLast { get; set; }

        public bool? IsActive { get; set; }
    }
}
