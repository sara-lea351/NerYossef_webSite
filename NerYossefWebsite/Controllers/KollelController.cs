using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KollelController : ControllerBase
    {
        private IKollelService _kollelService;
        public KollelController(IKollelService kollelService)
        {
            _kollelService = kollelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<kollelDTO>>> Get()
        {
            List<kollelDTO> kollelmen = await _kollelService.GetKollelmen();
            if (kollelmen == null)
                return NoContent();
            return Ok(kollelmen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<kollelDTO>>> Get(int id)
        {
            kollelDTO? kollelman = await _kollelService.GetKollelmanById(id);
            if (kollelman == null)
                return NotFound();
            return Ok(kollelman);
        }

        [HttpPost]
        public async Task<ActionResult<kollelWithDocumentsDTO>> CreateKollelman([FromBody] kollelWithDocumentsDTO kollelmanDto)
        {
            kollelWithDocumentsDTO result = await _kollelService.CreateKollelman(kollelmanDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<kollelDTO?>> Update(int kollelmanId, [FromBody] kollelDTO kollelmanDto)
        {
            kollelDTO? result = await _kollelService.Update(kollelmanId, kollelmanDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _kollelService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
