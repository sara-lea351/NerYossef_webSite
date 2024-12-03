using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private NerYossefDbContext _StudentContext;
        public StudentRepository(NerYossefDbContext StudentContext) 
        { 
            _StudentContext = StudentContext;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _StudentContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _StudentContext.Students.FindAsync(id);
        }

    }
}
