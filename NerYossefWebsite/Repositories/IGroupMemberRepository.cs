using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public interface IGroupMemberRepository
    {

        Task<List<GroupMember>> GetGroupMembers(int groupId);

        Task<GroupMember?> GetGroupMemberById(int groupId);

        Task<GroupMember?> CreateGroupMember(GroupMember groupMember);

        Task<GroupMember?> UpdateGroupMember(int groupMemberId, GroupMember newGroupMember);

        Task<bool> Delete(int groupMemberId);

    }
}
