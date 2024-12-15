using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<studentDTO>>> Get()
        //{
        //    List<studentDTO> students = await _documentService.GetStudents();
        //    if (students == null)
        //        return NoContent();
        //    return Ok(students);
        //}

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<documentDTO>>> GetDocumentsByPersonID(int personId)
        {
            List<documentDTO> documents = await _documentService.GetDocumentsByPersonId(personId);
            if (documents == null)
                return NotFound();
            return Ok(documents);
        }
    }
}
