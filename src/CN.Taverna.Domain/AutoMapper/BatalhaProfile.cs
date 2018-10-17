using AutoMapper;
using CN.Taverna.Domain.Dto.Batalha;
using CN.Taverna.Domain.Entities.Batalha;

namespace CN.Taverna.Domain.AutoMapper
{
    public class BatalhaProfile : Profile
    {
        public BatalhaProfile()
        {

            CreateMap<Heroi, HeroiBatalhaDto>();
            CreateMap<HeroiBatalhaDto, Heroi>();

            CreateMap<BatalhaDto, Batalha>()
                .ConvertUsing(cfg =>
                    new Batalha
                    {
                        Ganhador = Mapper.Map<Heroi>(cfg.Ganhador),
                        Perdedor = Mapper.Map<Heroi>(cfg.Perdedor)
                    });

            CreateMap<Batalha, BatalhaDto>()
                .ConvertUsing(cfg =>
                    new BatalhaDto()
                    {
                        Ganhador = Mapper.Map<HeroiBatalhaDto>(cfg.Ganhador),
                        Perdedor = Mapper.Map<HeroiBatalhaDto>(cfg.Perdedor)
                    });
        }
    }
}
