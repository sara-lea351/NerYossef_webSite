using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Services
{
    public interface IGroupMemberService
    {

        Task<List<groupMemberDTO>> GetGroupMembers(int groupId);

        Task<groupMemberDTO?> GetGroupMemberById(int groupId);

        Task<groupMemberDTO?> CreateGroupMember(groupMemberDTO groupMember);

        Task<groupMemberDTO?> UpdateGroupMember(int groupMemberId, groupMemberDTO newGroupMember);

        Task<bool> Delete(int groupMemberId);
    }
}
