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
            CreateMap<Samurai, SamuraiWithQuotesDTO>().ReverseMap();

            CreateMap<Quote, QuoteDTO>().ReverseMap();
            CreateMap<QuoteCreateDTO, Quote>();
            CreateMap<QuoteUpdateDTO, Quote>();

        }
    }
}
