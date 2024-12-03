using NerYossefWebsite.Models;

namespace NerYossefWebsite.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);

    }
}
