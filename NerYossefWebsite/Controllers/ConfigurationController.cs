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
    public class ConfigurationController : ControllerBase
    {
        private IConfigurationService _ConfigurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            _ConfigurationService = configurationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Configuration>>> Get()
        {
            List<Configuration> configurations = await _ConfigurationService.GetConfigurations();
            if (configurations == null)
                return NoContent();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> Get(int id)
        {
            Configuration? configuration = await _ConfigurationService.GetConfigurationByID(id);
            if (configuration == null)
                return NotFound();
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<ActionResult<Configuration>> CreateConfiguration([FromBody] Configuration configuration)
        {
            Configuration? result = await _ConfigurationService.CreateConfiguration(configuration);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Configuration?>> Update(int configurationId, [FromBody] Configuration configuration)
        {
            Configuration? result = await _ConfigurationService.UpdateConfiguration(configurationId, configuration);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _ConfigurationService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
