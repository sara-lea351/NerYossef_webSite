using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class DocumentService: IDocumentService
    {
        private IDocumentRepository _documentRepository;
        //private IDocumentTypeService _documentTypeService;
       
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<documentDTO>> GetDocumentsByPersonId(int personId)
        {
            return await _documentRepository.GetDocumentsByPersonId(personId);
        }

        public async Task<documentDTO> CreateDocument(documentDTO documentDto)
        {
            return await _documentRepository.CreateDocument(documentDto);
        }

        public async Task<bool> Delete(int documentId)
        {
            return await _documentRepository.Delete(documentId);
        }
    }
}
