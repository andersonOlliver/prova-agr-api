using AutoMapper;
using CN.Taverna.Domain.Dto.Especialidade;
using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Repositories;
using CN.Taverna.Domain.Interfaces.Services;

namespace CN.Taverna.Domain.Services
{
    public class EspecialidadeService : ServiceBase<EspecialidadeDto, Especialidade>, IEspecialidadeService
    {
        public EspecialidadeService(IEspecialidadeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
