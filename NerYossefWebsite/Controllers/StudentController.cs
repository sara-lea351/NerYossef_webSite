using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.Models;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            List<Student> students = await _studentService.GetStudents();
            if (students == null)
                return NoContent();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> Get(int id)
        {
            Student student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

    }
}
