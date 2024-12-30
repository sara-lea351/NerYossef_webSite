using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<documentTypeDTO>>> Get()
        {
            List<documentTypeDTO> documentType = await _documentTypeService.GetDocumentTypes();
            if (documentType == null)
                return NoContent();
            return Ok(documentType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<documentTypeDTO>>> Get(int id)
        {
            documentTypeDTO? documentType = await _documentTypeService.GetDocumentTypeByID(id);
            if (documentType == null)
                return NotFound();
            return Ok(documentType);
        }

        [HttpPost]
        public async Task<ActionResult<documentTypeDTO>> CreateDocumentType([FromBody] documentTypeDTO documentTypeDto)
        {
            documentTypeDTO result = await _documentTypeService.CreateDocumentType(documentTypeDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<documentTypeDTO?>> Update(int documentTypeId, [FromBody] documentTypeDTO documentTypeDto)
        {
            documentTypeDTO? result = await _documentTypeService.UpdateDocumentType(documentTypeId, documentTypeDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _documentTypeService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
