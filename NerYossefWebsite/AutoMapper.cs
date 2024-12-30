using AutoMapper;
using NerYossefWebsite.DTO_s;
using NerYossefWebsite.Models;

namespace NerYossefWebsite
{
    public class AutoMapper:Profile
    {
        public AutoMapper() 
        {
            CreateMap<Document, documentDTO>().ReverseMap();
            CreateMap<DocumentType, documentTypeDTO>().ReverseMap();
            //CreateMap<documentTypeDTO, DocumentType>();
            CreateMap<Alert, alertDTO>().ReverseMap();
            CreateMap<Group, groupDTO>().ReverseMap();
            CreateMap<GroupMember, groupMemberDTO>().ReverseMap();

        }

    }
}
