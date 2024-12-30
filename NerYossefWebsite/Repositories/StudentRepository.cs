using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private NerYossefDbContext _StudentContext;

        private readonly IDocumentService _DocumentService;

        public StudentRepository(NerYossefDbContext StudentContext, IDocumentService DocumentService) 
        { 
            _StudentContext = StudentContext;
            _DocumentService = DocumentService;
        }

        public async Task<List<studentDTO>> GetStudents()
        {
            var studentDetails = await (from student in _StudentContext.Students
                                 join person in _StudentContext.People on student.PersonId equals person.PersonId
                                 select new studentDTO
                                 {
                                     StudentId = student.StudentId,
                                     BirthDate = student.BirthDate,
                                     Class = student.Class,
                                     EntryDate = student.EntryDate,
                                     ExitDate = student.ExitDate,
                                     FatherMail = student.FatherMail,
                                     FatherName = student.FatherName,
                                     FatherPhone = student.FatherPhone,
                                     IsPaymentValid = student.IsPaymentValid,
                                     MotherMail = student.MotherMail,
                                     MotherName = student.MotherName,
                                     MotherPhone = student.MotherPhone,
                                     Payment = student.Payment,
                                     PaymentExpiryDate = student.PaymentExpiryDate,
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

            return studentDetails;
        }

        public async Task<studentDTO?> GetStudentById(int studentId)
        {
            var studentDetail = await (from student in _StudentContext.Students
                                       join person in _StudentContext.People on student.PersonId equals person.PersonId
                                       where student.StudentId == studentId
                                       select new studentDTO
                                       {
                                           StudentId = student.StudentId,
                                           BirthDate = student.BirthDate,
                                           Class = student.Class,
                                           EntryDate = student.EntryDate,
                                           ExitDate = student.ExitDate,
                                           FatherMail = student.FatherMail,
                                           FatherName = student.FatherName,
                                           FatherPhone = student.FatherPhone,
                                           IsPaymentValid = student.IsPaymentValid,
                                           MotherMail = student.MotherMail,
                                           MotherName = student.MotherName,
                                           MotherPhone = student.MotherPhone,
                                           Payment = student.Payment,
                                           PaymentExpiryDate = student.PaymentExpiryDate,
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

            return studentDetail;
        }

        public async Task<studentWithDocumentDTO> CreateStudent(studentWithDocumentDTO studentDto)
        {
            // Create a new Person entity from the studentDTO
            var person = new Person
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                NumberId = studentDto.NumberId,
                PassportNumber = studentDto.PassportNumber,
                Phone = studentDto.Phone,
                Email = studentDto.Email,
                Address = studentDto.Address,
                PersonType = "תלמיד"
            };

            // Add the new Person entity to the context (PersonId is auto-generated)
            _StudentContext.People.Add(person);

            // Save changes to get the person ID (since it is auto-generated)
            await _StudentContext.SaveChangesAsync();

            // Create a new Student entity from the studentDTO
            var student = new Student
            {
                PersonId = person.PersonId, // Set the PersonId to the newly created person's ID
                BirthDate = studentDto.BirthDate,
                FatherName = studentDto.FatherName,
                MotherName = studentDto.MotherName,
                FatherPhone = studentDto.FatherPhone,
                MotherPhone = studentDto.MotherPhone,
                FatherMail = studentDto.FatherMail,
                MotherMail = studentDto.MotherMail,
                Payment = studentDto.Payment,
                PaymentExpiryDate = studentDto.PaymentExpiryDate,
                IsPaymentValid = studentDto.IsPaymentValid,
                Class = studentDto.Class,
                EntryDate = studentDto.EntryDate,
                ExitDate = studentDto.ExitDate
            };

            _StudentContext.Students.Add(student);

            // Persist changes to the database (StudentId will be auto-generated)
            await _StudentContext.SaveChangesAsync();
            
            if(studentDto.Documents != null)
            { 
                foreach (documentDTO doc in studentDto.Documents)  
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
                    _StudentContext.Documents.Add(document);

                    // Persist changes to the database (StudentId will be auto-generated)
                    await _StudentContext.SaveChangesAsync();

                    doc.PersonId = person.PersonId;
                    doc.DocumentId = document.DocumentId;
                    doc.IsActive = isActive;
                }

            }

            // Map the result back to studentDTO and return
            studentDto.StudentId = student.StudentId; // Set the generated StudentId back to studentDTO
            studentDto.PersonId = person.PersonId; // Set the generated PersonId back to studentDTO

            return studentDto; // Return the DTO with generated IDs
        }

        public async Task<studentDTO?> Update(int studentId, studentDTO studentDto)
        {
            // Retrieve the student entity from the database
            var student = await _StudentContext.Students
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                // If no student found, return null or handle as needed
                return null;
            }

            // Retrieve the person entity associated with the student
            var person = await _StudentContext.People
                .FirstOrDefaultAsync(p => p.PersonId == student.PersonId);

            if (person == null)
            {
                // If no person found, return null or handle as needed
                return null;
            }

            // Update the Person entity with the new details from studentDto
            person.FirstName = studentDto.FirstName;
            person.LastName = studentDto.LastName;
            person.NumberId = studentDto.NumberId;
            person.PassportNumber = studentDto.PassportNumber;
            person.Phone = studentDto.Phone;
            person.Email = studentDto.Email;
            person.Address = studentDto.Address;
            person.PersonType = "תלמיד";

            studentDto.PersonType = "תלמיד"; //במקרה של שליחת סוג ששונה מתלמיד

            // Update the Student entity with the new details from studentDto
            student.BirthDate = studentDto.BirthDate;
            student.FatherName = studentDto.FatherName;
            student.MotherName = studentDto.MotherName;
            student.FatherPhone = studentDto.FatherPhone;
            student.MotherPhone = studentDto.MotherPhone;
            student.FatherMail = studentDto.FatherMail;
            student.MotherMail = studentDto.MotherMail;
            student.Payment = studentDto.Payment;
            student.PaymentExpiryDate = studentDto.PaymentExpiryDate;
            student.IsPaymentValid = studentDto.IsPaymentValid;
            student.Class = studentDto.Class;
            student.EntryDate = studentDto.EntryDate;
            student.ExitDate = studentDto.ExitDate;  // Can be null if necessary

            // Persist changes to the database
            await _StudentContext.SaveChangesAsync();

            return studentDto; // Return the updated studentDTO
        }


        public async Task<bool> Delete(int studentId)
        {
            // Retrieve the student entity from the database
            var student = await _StudentContext.Students
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                // If no student found, return false or handle as needed
                return false;
            }

            // Retrieve the person entity from the database
            var person = await _StudentContext.People
                .FirstOrDefaultAsync(s => s.PersonId == student.PersonId);

            if (person == null)
            {
                // If no student found, return false or handle as needed
                return false;
            }

            var documents = await _DocumentService.GetDocumentsByPersonId(student.PersonId);

            if (documents != null)
            {
                foreach (documentDTO document in documents)
                {
                    await _DocumentService.Delete(document.DocumentId);
                }
            }
            // Mark the entity for deletion
            _StudentContext.Students.Remove(student);
            _StudentContext.People.Remove(person);

            // Persist changes to the database
            await _StudentContext.SaveChangesAsync();

            return true; // Indicate successful deletion
        }

    }
}
