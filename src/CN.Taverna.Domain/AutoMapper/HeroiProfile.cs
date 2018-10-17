using AutoMapper;
using CN.Taverna.Domain.Dto.Heroi;
using CN.Taverna.Domain.Entities;

namespace CN.Taverna.Domain.AutoMapper
{
    public class HeroiProfile : Profile
    {
        public HeroiProfile()
        {
            CreateMap<RegistraHeroiDto, Heroi>().ReverseMap();
            CreateMap<DetalhaHeroiDto, Heroi>().ReverseMap();
        }
    }
}
