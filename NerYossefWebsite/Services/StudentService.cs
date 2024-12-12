using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;

namespace NerYossefWebsite.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<studentDTO>> GetStudents()
        {
             return await _studentRepository.GetStudents();
        }

        public async Task<studentDTO> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task<studentDTO> CreateStudent(studentDTO studentDto)
        {
            return await _studentRepository.CreateStudent(studentDto);
        }

        public async Task<studentDTO?> Update(int studentId, studentDTO studentDto)
        {
            return await _studentRepository.Update(studentId, studentDto);
        }

        public async Task<bool> Delete(int studentId)
        {
            return await _studentRepository.Delete(studentId);
        }
    }
}
