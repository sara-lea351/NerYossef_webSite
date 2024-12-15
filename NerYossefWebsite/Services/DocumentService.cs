using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class DocumentService: IDocumentService
    {
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<documentDTO>> GetDocumentsByPersonId(int personId)
        {
            return await _documentRepository.GetDocumentsByPersonId(personId);
        }
    }
}
