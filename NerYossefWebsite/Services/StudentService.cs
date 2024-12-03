using NerYossefWebsite.Models;
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
        public async Task<List<Student>> GetStudents()
        {
             return await _studentRepository.GetStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }
    }
}
