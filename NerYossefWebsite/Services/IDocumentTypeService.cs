using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Services
{
    public interface IDocumentTypeService
    {

        Task<List<documentTypeDTO>> GetDocumentTypes();

        Task<documentTypeDTO?> GetDocumentTypeByID(int documentTypeId);

        Task<documentTypeDTO> CreateDocumentType(documentTypeDTO documentTypeDto);

        Task<documentTypeDTO?> UpdateDocumentType(int documentTypeId, documentTypeDTO documentTypeDto);

        Task<bool> Delete(int documentTypeId);
    }
}
