using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        private studentValidation _studentValidation;
        public StudentService(IStudentRepository studentRepository, studentValidation studentValidation) 
        {
            _studentRepository = studentRepository;
            _studentValidation = studentValidation;
        }

        public async Task<List<studentDTO>> GetStudents()
        {
             return await _studentRepository.GetStudents();
        }

        public async Task<studentDTO?> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task<studentWithDocumentDTO> CreateStudent(studentWithDocumentDTO studentDto)
        {
            _studentValidation.validate(studentDto);
            studentDto.IsPaymentValid = studentDto.PaymentExpiryDate > DateOnly.FromDateTime(DateTime.Now); // TRUE אם התאריך לא עבר, אחרת FALSE
            return await _studentRepository.CreateStudent(studentDto);
        }

        public async Task<studentDTO?> Update(int studentId, studentDTO studentDto)
        {
            _studentValidation.validate(studentDto);
            return await _studentRepository.Update(studentId, studentDto);
        }

        public async Task<bool> Delete(int studentId)
        {   
            return await _studentRepository.Delete(studentId);
        }
    }
}
