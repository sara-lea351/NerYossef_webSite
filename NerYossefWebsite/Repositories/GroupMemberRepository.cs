using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {

        private readonly NerYossefDbContext _GroupMemberContext;

        public GroupMemberRepository(NerYossefDbContext GroupMemberContext)
        {
            _GroupMemberContext = GroupMemberContext;
        }

        public async Task<List<GroupMember>> GetGroupMembers(int groupId)
        {
            return await (from groupMember in _GroupMemberContext.GroupMembers
                          where groupMember.GroupId == groupId
                          select groupMember).ToListAsync();
        }

        public async Task<GroupMember?> GetGroupMemberById(int groupMemberId)
        {
            return await _GroupMemberContext.GroupMembers
                .FirstOrDefaultAsync(s => s.GroupMemberId == groupMemberId);
        }

        public async Task<GroupMember?> CreateGroupMember(GroupMember groupMember)
        {
            _GroupMemberContext.GroupMembers.Add(groupMember);
            await _GroupMemberContext.SaveChangesAsync();
            return groupMember;
        }

        public async Task<GroupMember?> UpdateGroupMember(int groupMemberId, GroupMember groupMember)
        {
            var existingGroupMember = await _GroupMemberContext.GroupMembers
                .FirstOrDefaultAsync(s => s.GroupMemberId == groupMemberId);

            if (existingGroupMember == null)
            {
                return null;
            }

            existingGroupMember.FirstName = groupMember.FirstName;
            existingGroupMember.LastName = groupMember.LastName;
            existingGroupMember.Phone = groupMember.Phone;
            existingGroupMember.Email = groupMember.Email;
            existingGroupMember.GroupId = groupMember.GroupId;



            await _GroupMemberContext.SaveChangesAsync();
            return existingGroupMember; // Return the updated entity
        }

        public async Task<bool> Delete(int groupMemberId)
        {
            var groupMember = await _GroupMemberContext.GroupMembers
                .FirstOrDefaultAsync(s => s.GroupMemberId == groupMemberId);

            if (groupMember == null)
            {
                return false;
            }

            _GroupMemberContext.GroupMembers.Remove(groupMember);
            await _GroupMemberContext.SaveChangesAsync();
            return true; // Indicate successful deletion
        }
    }
}

