namespace NerYossefWebsite.DTO_s
{
    public class kollelWithDocumentsDTO:kollelDTO
    {
        public ICollection<documentDTO>? Documents { get; set; } = new List<documentDTO>();
    }
}
