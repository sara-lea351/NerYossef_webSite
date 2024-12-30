using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _GroupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _GroupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<groupDTO>> GetGroups()
        {
            var groups = await _GroupRepository.GetGroups();
            return _mapper.Map<List<groupDTO>>(groups);
        }

        public async Task<groupDTO?> GetGroupByID(int groupId)
        {
            var group = await _GroupRepository.GetGroupByID(groupId);
            return _mapper.Map<groupDTO>(group);
        }

        public async Task<groupDTO?> CreateGroup(groupDTO groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            var createdGroup = await _GroupRepository.CreateGroup(group);
            return _mapper.Map<groupDTO>(createdGroup);
        }

        public async Task<groupDTO?> UpdateGroup(int groupId, groupDTO groupDto)
        {
            var group = await _GroupRepository.UpdateGroup(groupId, _mapper.Map<Group>(groupDto));
            return _mapper.Map<groupDTO>(group);
        }

        public async Task<bool> Delete(int groupId)
        {
            return await _GroupRepository.Delete(groupId);
        }

    }
}
