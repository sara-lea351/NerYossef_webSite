using NerYossefWebsite.DTO_s;

namespace NerYossefWebsite.Services
{
    public interface IGroupService
    {
        Task<List<groupDTO>> GetGroups();

        Task<groupDTO?> GetGroupByID(int groupId);

        Task<groupDTO?> CreateGroup(groupDTO group);

        Task<groupDTO?> UpdateGroup(int groupId, groupDTO newGroup);

        Task<bool> Delete(int groupId);
    }
}
