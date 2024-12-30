using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite.Repositories
{
    public interface IGroupRepository
    {

        Task<List<Group>> GetGroups();

        Task<Group?> GetGroupByID(int groupId);

        Task<Group?> CreateGroup(Group group);
        Task<Group?> UpdateGroup(int groupId, Group newGroup);

        Task<bool> Delete(int groupId);

    }
}
