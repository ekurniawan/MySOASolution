using AutoMapper;
using MySOASolution.BLL.DTOs;
using MySOASolution.Domain;

namespace MySOASolution.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Samurai, SamuraiDTO>().ReverseMap();
            CreateMap<SamuraiCreateDTO, Samurai>();
            CreateMap<SamuraiUpdateDTO, Samurai>();

            CreateMap<Quote, QuoteDTO>().ReverseMap();
        }
    }
}
