using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;
using NerYossefWebsite.NewFolder;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services.ServiceValidations;

namespace NerYossefWebsite.Services
{
    public class GroupMemberService : IGroupMemberService
    {

        private readonly IGroupMemberRepository _GroupMemberRepository;
        private readonly IGroupService _groupService;
        private readonly groupMemberValidation _groupMemberValidation;
        private readonly IMapper _mapper;

        public GroupMemberService(IGroupMemberRepository groupMemberRepository, groupMemberValidation groupMemberValidation, IGroupService groupService ,IMapper mapper)
        {
            _GroupMemberRepository = groupMemberRepository;
            _groupMemberValidation = groupMemberValidation;
            _groupService = groupService;
            _mapper = mapper;
        }

        public async Task<List<groupMemberDTO>> GetGroupMembers(int id)
        {
            var groupMembers = await _GroupMemberRepository.GetGroupMembers(id);
            return _mapper.Map<List<groupMemberDTO>>(groupMembers);
        }

        public async Task<groupMemberDTO?> GetGroupMemberById(int groupMemberId)
        {
            var groupMember = await _GroupMemberRepository.GetGroupMemberById(groupMemberId);
            return _mapper.Map<groupMemberDTO>(groupMember);
        }

        public async Task<groupMemberDTO?> CreateGroupMember(groupMemberDTO groupMemberDto)
        {
            var groupMember = _mapper.Map<GroupMember>(groupMemberDto);

            var group = await _groupService.GetGroupByID(groupMemberDto.GroupId);
            if ( group == null)
                throw new ArgumentException("יש להזין ID של קבוצה קיימת.");

            _groupMemberValidation.validate(groupMemberDto);

            var createdGroupMember = await _GroupMemberRepository.CreateGroupMember(groupMember);
            return _mapper.Map<groupMemberDTO>(createdGroupMember);
        }

        public async Task<groupMemberDTO?> UpdateGroupMember(int groupMemberId, groupMemberDTO groupMemberDto)
        {
            _groupMemberValidation.validate(groupMemberDto);
            var groupMember = await _GroupMemberRepository.UpdateGroupMember(groupMemberId, _mapper.Map<GroupMember>(groupMemberDto));
            return _mapper.Map<groupMemberDTO>(groupMember);
        }

        public async Task<bool> Delete(int groupMemberId)
        {
            return await _GroupMemberRepository.Delete(groupMemberId);
        }

    }
}
