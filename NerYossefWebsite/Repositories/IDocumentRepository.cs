using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Repositories
{
    public interface IDocumentRepository
    {
        Task<List<documentDTO>> GetDocumentsByPersonId(int personId);
    }
}
