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
    public class GroupMemberController : ControllerBase
    {
        private IGroupMemberService _GroupMemberService;
        public GroupMemberController(IGroupMemberService GroupMemberService)
        {
            _GroupMemberService = GroupMemberService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<groupMemberDTO>>> Get(int id)
        {
            List<groupMemberDTO> groupMembers = await _GroupMemberService.GetGroupMembers(id);
            if (groupMembers == null)
                return NotFound();
            return Ok(groupMembers);
        }

        [HttpGet("GroupMember/{groupMemberId}")]
        public async Task<ActionResult<List<groupMemberDTO?>>> GetGroupMemberID(int groupMemberId)
        {
            groupMemberDTO? groupMember = await _GroupMemberService.GetGroupMemberById(groupMemberId);
            if (groupMember == null)
                return NotFound();
            return Ok(groupMember);
        }

        [HttpPost]
        public async Task<ActionResult<groupMemberDTO?>> Create([FromBody] groupMemberDTO groupMemberDto)
        {
            groupMemberDTO? result = await _GroupMemberService.CreateGroupMember(groupMemberDto);
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<groupMemberDTO?>> Update(int groupMemberId, [FromBody] groupMemberDTO groupMemberDto)
        {
            groupMemberDTO? result = await _GroupMemberService.UpdateGroupMember(groupMemberId, groupMemberDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _GroupMemberService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();

        }
    }
}
