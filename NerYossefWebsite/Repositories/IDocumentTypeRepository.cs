using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public interface IDocumentTypeRepository
    {

        Task<List<DocumentType>> GetDocumentTypes();

        Task<DocumentType?> GetDocumentTypeByID(int documentTypeId);

        Task<DocumentType> CreateDocumentType(DocumentType documentTypeDto);

        Task<DocumentType?> UpdateDocumentType(int documentTypeId, DocumentType documentTypeDto);

        Task<bool> Delete(int documentTypeId);

    }
}
