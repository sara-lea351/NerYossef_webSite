using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;

namespace NerYossefWebsite.Repositories
{
    public class GroupRepository : IGroupRepository
    {

        private readonly NerYossefDbContext _GroupContext;

        public GroupRepository(NerYossefDbContext GroupContext)
        {
            _GroupContext = GroupContext;
        }

        public async Task<List<Group>> GetGroups()
        {
            return await _GroupContext.Groups.ToListAsync();
        }

        public async Task<Group?> GetGroupByID(int groupId)
        {
            return await _GroupContext.Groups
                .FirstOrDefaultAsync(s => s.GroupId == groupId);
        }

        public async Task<Group?> CreateGroup(Group group)
        {
            _GroupContext.Groups.Add(group);
            await _GroupContext.SaveChangesAsync();
            return group;
        }

        public async Task<Group?> UpdateGroup(int groupId, Group group)
        {
            var existingGroup = await _GroupContext.Groups
                .FirstOrDefaultAsync(s => s.GroupId == groupId);

            if (existingGroup == null)
            {
                return null;
            }

            existingGroup.GroupName = group.GroupName;

            await _GroupContext.SaveChangesAsync();
            return existingGroup; // Return the updated entity
        }

        public async Task<bool> Delete(int groupId)
        {
            var group = await _GroupContext.Groups
                .FirstOrDefaultAsync(s => s.GroupId == groupId);

            if (group == null)
            {
                return false;
            }

            _GroupContext.Groups.Remove(group);
            await _GroupContext.SaveChangesAsync();
            return true; // Indicate successful deletion
        }
    }
}

