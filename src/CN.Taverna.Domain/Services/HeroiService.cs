using AutoMapper;
using CN.Taverna.Domain.Dto.Heroi;
using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Repositories;
using CN.Taverna.Domain.Interfaces.Services;

namespace CN.Taverna.Domain.Services
{
    public class HeroiService : ServiceBase<HeroiDto, Heroi>, IHeroiService
    {
        public HeroiService(IHeroiRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

