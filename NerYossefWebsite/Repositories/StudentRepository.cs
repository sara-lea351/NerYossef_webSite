﻿using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private NerYossefDbContext _StudentContext;
        public StudentRepository(NerYossefDbContext StudentContext) 
        { 
            _StudentContext = StudentContext;
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

        public async Task<studentDTO> CreateStudent(studentDTO studentDto)
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
                PersonType = studentDto.PersonType
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




            // Add the new Student entity to the context (StudentId is auto-generated)
            _StudentContext.Students.Add(student);

            // Persist changes to the database (StudentId will be auto-generated)
            await _StudentContext.SaveChangesAsync();

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
            person.PersonType = studentDto.PersonType;

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

            // Mark the entity for deletion
            _StudentContext.Students.Remove(student);
            _StudentContext.People.Remove(person);

            // Persist changes to the database
            await _StudentContext.SaveChangesAsync();

            return true; // Indicate successful deletion
        }

    }
}
