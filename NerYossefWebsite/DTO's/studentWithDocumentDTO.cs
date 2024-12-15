using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.DTO_s
{
    public class studentWithDocumentDTO: studentDTO
    {
        public ICollection<documentDTO>? Documents { get; set; } = new List<documentDTO>();
    }
}
