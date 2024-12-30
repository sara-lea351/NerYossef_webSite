using System.Drawing;
using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Repositories
{
    public class KollelRepository:IKollelRepository
    {
        private NerYossefDbContext _KollelContext;

        private readonly IDocumentService _DocumentService;

        public KollelRepository(NerYossefDbContext KollelContext, IDocumentService DocumentService)
        {
            _KollelContext = KollelContext;
            _DocumentService = DocumentService;
        }

        public async Task<List<kollelDTO>> GetKollelmen()
        {
            var kollelmenDetails = await (from kollelman in _KollelContext.Kollels
                                          join person in _KollelContext.People on kollelman.PersonId equals person.PersonId
                                          select new kollelDTO
                                          {
                                              KollelId = kollelman.KollelId,
                                              IsActive = kollelman.IsActive,
                                              Donor = kollelman.Donor,
                                              PersonId = person.PersonId,
                                              Address = person.Address,
                                              Email = person.Email,
                                              FirstName = person.FirstName,
                                              LastName = person.LastName,
                                              NumberId = person.NumberId,
                                              PassportNumber = person.PassportNumber,
                                              PersonType = person.PersonType,
                                              Phone = person.Phone
                                          }).ToListAsync();

            return kollelmenDetails;
        }

        public async Task<kollelDTO?> GetKollelmanById(int kollelmanId)
        {
            var kollelmanDetails = await (from kollelman in _KollelContext.Kollels
                                       join person in _KollelContext.People on kollelman.PersonId equals person.PersonId
                                       where kollelman.KollelId == kollelmanId
                                       select new kollelDTO
                                       {
                                           KollelId = kollelman.KollelId,
                                           IsActive = kollelman.IsActive,
                                           Donor = kollelman.Donor,
                                           PersonId = person.PersonId,
                                           Address = person.Address,
                                           Email = person.Email,
                                           FirstName = person.FirstName,
                                           LastName = person.LastName,
                                           NumberId = person.NumberId,
                                           PassportNumber = person.PassportNumber,
                                           PersonType = person.PersonType,
                                           Phone = person.Phone

                                       }).FirstOrDefaultAsync(); // Use FirstOrDefaultAsync to get a single result

            return kollelmanDetails;
        }

        public async Task<kollelWithDocumentsDTO> CreateKollelman(kollelWithDocumentsDTO kollelmanDto)
        {
            // Create a new Person entity from the studentDTO
            var person = new Person
            {
                FirstName = kollelmanDto.FirstName,
                LastName = kollelmanDto.LastName,
                NumberId = kollelmanDto.NumberId,
                PassportNumber = kollelmanDto.PassportNumber,
                Phone = kollelmanDto.Phone,
                Email = kollelmanDto.Email,
                Address = kollelmanDto.Address,
                PersonType = kollelmanDto.PersonType
            };

            // Add the new Person entity to the context (PersonId is auto-generated)
            _KollelContext.People.Add(person);

            // Save changes to get the person ID (since it is auto-generated)
            await _KollelContext.SaveChangesAsync();

            // Create a new Student entity from the studentDTO
            var kollelman = new Kollel
            {
                PersonId = person.PersonId, // Set the PersonId to the newly created person's ID
                Donor = kollelmanDto.Donor,
                IsActive = kollelmanDto.IsActive
            };

            _KollelContext.Kollels.Add(kollelman);

            // Persist changes to the database (StudentId will be auto-generated)
            await _KollelContext.SaveChangesAsync();
            if(kollelmanDto.Documents != null)
            { 
                foreach (documentDTO doc in kollelmanDto.Documents)
                {
                    bool isActive; // הגדרת המשתנה isActive

                    if (doc.ExpiryDate.HasValue) // אם יש תאריך
                        isActive = doc.ExpiryDate > DateOnly.FromDateTime(DateTime.Now); // TRUE אם התאריך לא עבר, אחרת FALSE
                    else
                        isActive = true; // אם אין תאריך, אז TRUE

                    var document = new Document
                    {
                        PersonId = person.PersonId,
                        DocumentTypeId = doc.DocumentTypeId,
                        DocumentPath = doc.DocumentPath,
                        ExpiryDate = doc.ExpiryDate,
                        UploadedAt = DateOnly.FromDateTime(DateTime.Now),
                        IsLast = true,
                        IsActive = isActive // כאן מכניסים את ערך isActive
                    };
                    _KollelContext.Documents.Add(document);

                    // Persist changes to the database (StudentId will be auto-generated)
                    await _KollelContext.SaveChangesAsync();

                    doc.PersonId = person.PersonId;
                    doc.DocumentId = document.DocumentId;
                    doc.IsActive = isActive;
                }
            }
            // Map the result back to studentDTO and return
            kollelmanDto.KollelId = kollelman.KollelId; // Set the generated StudentId back to studentDTO
            kollelmanDto.PersonId = person.PersonId; // Set the generated PersonId back to studentDTO

            return kollelmanDto; // Return the DTO with generated IDs
        }

        public async Task<kollelDTO?> Update(int kollelmanId, kollelDTO kollelmanDto)
        {
            // Retrieve the student entity from the database
            var kollelman = await _KollelContext.Kollels
                .FirstOrDefaultAsync(s => s.KollelId == kollelmanId);

            if (kollelman == null)
            {
                // If no student found, return null or handle as needed
                return null;
            }

            // Retrieve the person entity associated with the student
            var person = await _KollelContext.People
                .FirstOrDefaultAsync(p => p.PersonId == kollelman.PersonId);

            if (person == null)
            {
                // If no person found, return null or handle as needed
                return null;
            }

            // Update the Person entity with the new details from studentDto
            person.FirstName = kollelmanDto.FirstName;
            person.LastName = kollelmanDto.LastName;
            person.NumberId = kollelmanDto.NumberId;
            person.PassportNumber = kollelmanDto.PassportNumber;
            person.Phone = kollelmanDto.Phone;
            person.Email = kollelmanDto.Email;
            person.Address = kollelmanDto.Address;
            person.PersonType = kollelmanDto.PersonType;



            // Update the Student entity with the new details from studentDto
            kollelman.Donor = kollelmanDto.Donor;
            kollelman.IsActive = kollelmanDto.IsActive; 

            // Persist changes to the database
            await _KollelContext.SaveChangesAsync();

            return kollelmanDto; // Return the updated studentDTO
        }


        public async Task<bool> Delete(int kollelmanId)
        {
            // Retrieve the student entity from the database
            var kollelman = await _KollelContext.Kollels
                .FirstOrDefaultAsync(s => s.KollelId == kollelmanId);

            if (kollelman == null)
            {
                // If no student found, return false or handle as needed
                return false;
            }

            // Retrieve the person entity from the database
            var person = await _KollelContext.People
                .FirstOrDefaultAsync(s => s.PersonId == kollelman.PersonId);

            if (person == null)
            {
                // If no student found, return false or handle as needed
                return false;
            }

            var documents = await _DocumentService.GetDocumentsByPersonId(person.PersonId);

            if (documents != null)
            {
                foreach (documentDTO document in documents)
                {
                    await _DocumentService.Delete(document.DocumentId);
                }
            }
            // Mark the entity for deletion
            _KollelContext.Kollels.Remove(kollelman);
            _KollelContext.People.Remove(person);

            // Persist changes to the database
            await _KollelContext.SaveChangesAsync();

            return true; // Indicate successful deletion
        }

    }
}
