using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace CN.Taverna.Infra.Repository
{
    public class EspecialidadeRepository : RepositoryBase<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}