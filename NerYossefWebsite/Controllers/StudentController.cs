using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
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
        public async Task<ActionResult<List<studentDTO>>> Get()
        {
            List<studentDTO> students = await _studentService.GetStudents();
            if (students == null)
                return NoContent();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<studentDTO>>> Get(int id)
        {
            studentDTO student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<studentDTO>> CreateStudent( [FromBody] studentDTO studentDto)
        {
            studentDTO result = await _studentService.CreateStudent(studentDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<studentDTO?>> Update(int studentId, [FromBody] studentDTO studentDto)
        {
            studentDTO result = await _studentService.Update(studentId, studentDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _studentService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
