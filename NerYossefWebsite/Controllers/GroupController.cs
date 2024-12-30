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
    public class GroupController : ControllerBase
    {
        private IGroupService _GroupService;
        public GroupController(IGroupService GroupService)
        {
            _GroupService = GroupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<groupDTO>>> Get()
        {
            List<groupDTO> group = await _GroupService.GetGroups();
            if (group == null)
                return NoContent();
            return Ok(group);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<groupDTO>>> Get(int id)
        {
            groupDTO? group = await _GroupService.GetGroupByID(id);
            if (group == null)
                return NotFound();
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<groupDTO?>> Create([FromBody] groupDTO groupDto)
        {
            groupDTO? result = await _GroupService.CreateGroup(groupDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<groupDTO?>> Update(int groupId, [FromBody] groupDTO groupDto)
        {
            groupDTO? result = await _GroupService.UpdateGroup(groupId, groupDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _GroupService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
