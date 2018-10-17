using CN.Taverna.Domain.Entities.Batalha;
using CN.Taverna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace CN.Taverna.Infra.Repository
{
    public class BatalhaRepository : RepositoryBase<Batalha>, IBatalhaRepository
    {
        public BatalhaRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
