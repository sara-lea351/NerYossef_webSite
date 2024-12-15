using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private NerYossefDbContext _DocumentContext;
        public DocumentRepository(NerYossefDbContext DocumentContext)
        {
            _DocumentContext = DocumentContext;
        }

        public async Task<List<documentDTO>> GetDocumentsByPersonId(int personId)
        {
            var documents = await (from document in _DocumentContext.Documents
                                   join person in _DocumentContext.People on document.PersonId equals person.PersonId
                                   where document.PersonId == personId
                                   select new documentDTO
                                   {
                                       PersonId = document.PersonId,
                                       DocumentTypeId = document.DocumentTypeId,
                                       DocumentPath = document.DocumentPath,
                                       ExpiryDate = document.ExpiryDate,
                                       UploadedAt = document.UploadedAt,
                                       IsLast = document.IsLast,
                                       IsActive = document.IsActive

                                   }).ToListAsync();
            return documents;

        }
    }
}

