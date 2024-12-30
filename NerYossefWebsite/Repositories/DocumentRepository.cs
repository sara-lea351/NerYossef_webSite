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
                                       DocumentId = document.DocumentId,
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

        public async Task<documentDTO> CreateDocument(documentDTO documentDto)
        {
            bool isActive; // הגדרת המשתנה isActive

            if (documentDto.ExpiryDate.HasValue) // אם יש תאריך
                isActive = documentDto.ExpiryDate > DateOnly.FromDateTime(DateTime.Now); // TRUE אם התאריך לא עבר, אחרת FALSE
            else
                isActive = true; // אם אין תאריך, אז TRUE

            // Create a new Person entity from the studentDTO
            var document = new Document
            {
                PersonId = documentDto.PersonId,
                DocumentTypeId = documentDto.DocumentTypeId,
                DocumentPath = documentDto.DocumentPath,
                ExpiryDate = documentDto.ExpiryDate,
                UploadedAt = DateOnly.FromDateTime(DateTime.Now),
                IsLast = true,
                IsActive = isActive
            };

            _DocumentContext.Documents.Add(document);

            // Persist changes to the database (StudentId will be auto-generated)
            await _DocumentContext.SaveChangesAsync();

            documentDto.DocumentId = document.DocumentId;
            documentDto.IsActive = isActive;

            return documentDto; // Return the DTO with generated IDs
        }

        public async Task<bool> Delete(int documentId)
        {

            // Retrieve the document entity from the database
            var document = await _DocumentContext.Documents
                .FirstOrDefaultAsync(s => s.DocumentId == documentId);

            if (document == null)
            {
                // If no document found, return false or handle as needed
                return false;
            }

            _DocumentContext.Documents.Remove(document);
            // Persist changes to the database
            await _DocumentContext.SaveChangesAsync();

            return true; // Indicate successful deletion
        }   
    }
}

