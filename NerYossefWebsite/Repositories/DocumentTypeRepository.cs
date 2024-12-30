using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {

        private readonly NerYossefDbContext _DocumentTypeContext;

        public DocumentTypeRepository(NerYossefDbContext DocumentTypeContext)
        {
            _DocumentTypeContext = DocumentTypeContext;
        }

        public async Task<List<DocumentType>> GetDocumentTypes()
        {
            return await _DocumentTypeContext.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType?> GetDocumentTypeByID(int documentTypeId)
        {
            return await _DocumentTypeContext.DocumentTypes
                .FirstOrDefaultAsync(s => s.DocumentTypeId == documentTypeId);
        }

        public async Task<DocumentType> CreateDocumentType(DocumentType documentType)
        {
            _DocumentTypeContext.DocumentTypes.Add(documentType);
            await _DocumentTypeContext.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType?> UpdateDocumentType(int documentTypeId, DocumentType documentType)
        {
            var existingDocumentType = await _DocumentTypeContext.DocumentTypes
                .FirstOrDefaultAsync(s => s.DocumentTypeId == documentTypeId);

            if (existingDocumentType == null)
            {
                return null;
            }

            existingDocumentType.Type = documentType.Type;
            existingDocumentType.HasExpiryDate = documentType.HasExpiryDate;
            existingDocumentType.ExpiryWarningPeriod = documentType.ExpiryWarningPeriod;

            await _DocumentTypeContext.SaveChangesAsync();
            return existingDocumentType; // Return the updated entity
        }

        public async Task<bool> Delete(int documentTypeId)
        {
            var documentType = await _DocumentTypeContext.DocumentTypes
                .FirstOrDefaultAsync(s => s.DocumentTypeId == documentTypeId);

            if (documentType == null)
            {
                return false;
            }

            _DocumentTypeContext.DocumentTypes.Remove(documentType);
            await _DocumentTypeContext.SaveChangesAsync();
            return true; // Indicate successful deletion
        }
        //private NerYossefDbContext _DocumentTypeContext;
        //public DocumentTypeRepository(NerYossefDbContext DocumentTypeContext)
        //{
        //    _DocumentTypeContext = DocumentTypeContext;
        //}

        //public async Task<List<documentTypeDTO>> GetDocumentTypes()
        //{
        //    var documentTypes = await (from documentType in _DocumentTypeContext.DocumentTypes
        //                               select new documentTypeDTO
        //                               {    
        //                                    DocumentTypeId = documentType.DocumentTypeId,
        //                                    HasExpiryDate = documentType.HasExpiryDate,
        //                                    ExpiryWarningPeriod = documentType.ExpiryWarningPeriod, 
        //                                    Type = documentType.Type

        //                               }).ToListAsync();
        //    return documentTypes;
        //}

        //public async Task<documentTypeDTO?> GetDocumentTypeByID(int documentTypeId)
        //{
        //    var documentTypeDetails = await (from documentType in _DocumentTypeContext.DocumentTypes
        //                                     where documentType.DocumentTypeId == documentTypeId
        //                                  select new documentTypeDTO
        //                                  {
        //                                      DocumentTypeId = documentType.DocumentTypeId,
        //                                      HasExpiryDate = documentType.HasExpiryDate,
        //                                      ExpiryWarningPeriod = documentType.ExpiryWarningPeriod,
        //                                      Type = documentType.Type

        //                                  }).FirstOrDefaultAsync(); // Use FirstOrDefaultAsync to get a single result

        //    return documentTypeDetails;
        //}

        //public async Task<documentTypeDTO> CreateDocumentType(documentTypeDTO documentTypeDto)
        //{

        //    // Create a new Person entity from the studentDTO
        //    var documentType = new DocumentType
        //    {
        //        DocumentTypeId = documentTypeDto.DocumentTypeId,
        //        HasExpiryDate = documentTypeDto.HasExpiryDate,
        //        ExpiryWarningPeriod = documentTypeDto.ExpiryWarningPeriod,
        //        Type = documentTypeDto.Type
        //    };

        //    _DocumentTypeContext.DocumentTypes.Add(documentType);

        //    // Persist changes to the database (StudentId will be auto-generated)
        //    await _DocumentTypeContext.SaveChangesAsync();

        //    documentTypeDto.DocumentTypeId = documentType.DocumentTypeId;

        //    return documentTypeDto; // Return the DTO with generated IDs
        //}

        //public async Task<documentTypeDTO?> UpdateDocumentType(int documentTypeId, documentTypeDTO documentTypeDto)
        //{
        //    // Retrieve the student entity from the database
        //    var documentType = await _DocumentTypeContext.DocumentTypes
        //        .FirstOrDefaultAsync(s => s.DocumentTypeId == documentTypeId);

        //    if (documentType == null)
        //    {
        //        // If no student found, return null or handle as needed
        //        return null;
        //    }

        //    // Update the Person entity with the new details from studentDto
        //    documentType.Type = documentTypeDto.Type;
        //    documentType.HasExpiryDate = documentTypeDto.HasExpiryDate;
        //    documentType.ExpiryWarningPeriod = documentTypeDto.ExpiryWarningPeriod;

        //    // Persist changes to the database
        //    await _DocumentTypeContext.SaveChangesAsync();

        //    return documentTypeDto; // Return the updated studentDTO
        //}

        //public async Task<bool> Delete(int documentTypeId)
        //{

        //    // Retrieve the document entity from the database
        //    var documentType = await _DocumentTypeContext.DocumentTypes
        //        .FirstOrDefaultAsync(s => s.DocumentTypeId == documentTypeId);

        //    if (documentType == null)
        //    {
        //        // If no document found, return false or handle as needed
        //        return false;
        //    }

        //    _DocumentTypeContext.DocumentTypes.Remove(documentType);
        //    // Persist changes to the database
        //    await _DocumentTypeContext.SaveChangesAsync();

        //    return true; // Indicate successful deletion
        //}   
    }
}

