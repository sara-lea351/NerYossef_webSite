using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Services
{
    public interface IDocumentService
    {
        Task<List<documentDTO>> GetDocumentsByPersonId(int personId);
    }
}
