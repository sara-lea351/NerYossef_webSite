using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);

    }
}
