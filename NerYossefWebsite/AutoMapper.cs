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
        }
        
    }
}
