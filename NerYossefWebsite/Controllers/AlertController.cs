using Microsoft.AspNetCore.Mvc;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Services;

namespace NerYossefWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {

        private IAlertService _alertService;
        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet]
        public async Task<ActionResult<List<alertDTO>>> Get()
        {
            List<alertDTO> alerts = await _alertService.GetAlerts();
            if (alerts == null)
                return NoContent();
            return Ok(alerts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<alertDTO>>> Get(int id)
        {
            alertDTO? alert = await _alertService.GetAlertByID(id);
            if (alert == null)
                return NotFound();
            return Ok(alert);
        }

        [HttpGet("person/{personId}")]
        public async Task<ActionResult<List<alertDTO>>> GetAlertsByPersonID(int personId)
        {
            List<alertDTO?> alerts = await _alertService.GetAlertByPersonID(personId);
            if (!alerts.Any())
                return NotFound();
            return Ok(alerts);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<alertDTO?>> Update(int alertId, [FromBody] alertDTO alertDto)
        {
            alertDTO? result = await _alertService.UpdateAlert(alertId, alertDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _alertService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
