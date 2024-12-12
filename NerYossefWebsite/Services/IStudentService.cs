using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Services
{
    public interface IStudentService
    {
        Task<List<studentDTO>> GetStudents();
        Task<studentDTO> GetStudentById(int id);
        Task<studentDTO> CreateStudent(studentDTO studentDto);
        Task<studentDTO?> Update(int studentId, studentDTO studentDto);
        Task<bool> Delete(int studentId);
    }
}
