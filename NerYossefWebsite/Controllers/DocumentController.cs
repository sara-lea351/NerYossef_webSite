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

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<documentDTO>>> GetDocumentsByPersonID(int personId)
        {
            List<documentDTO> documents = await _documentService.GetDocumentsByPersonId(personId);
            if (!documents.Any())
                return NotFound();
            return Ok(documents);
        }

        [HttpPost]
        public async Task<ActionResult<documentDTO>> CreateDocument(documentDTO documentDto)
        {
            documentDTO result = await _documentService.CreateDocument(documentDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _documentService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
