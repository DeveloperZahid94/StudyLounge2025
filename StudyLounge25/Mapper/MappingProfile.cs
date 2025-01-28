using AutoMapper;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;

namespace StudyLounge25.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<studentDTO, StudentModal>().ReverseMap();
        }
    }
}
