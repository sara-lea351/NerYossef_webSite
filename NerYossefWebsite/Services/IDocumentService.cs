using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Services
{
    public interface IDocumentService
    {
        Task<List<documentDTO>> GetDocumentsByPersonId(int personId);
        Task<documentDTO> CreateDocument(documentDTO documentDto);
        Task<bool> Delete(int documentId);
    }
}
