using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace CN.Taverna.Infra.Repository
{
    public class HeroiRepository : RepositoryBase<Heroi>, IHeroiRepository
    {
        public HeroiRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
