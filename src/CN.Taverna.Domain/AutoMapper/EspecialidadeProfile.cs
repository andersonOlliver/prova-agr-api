using AutoMapper;
using CN.Taverna.Domain.Dto.Especialidade;
using CN.Taverna.Domain.Entities;

namespace CN.Taverna.Domain.AutoMapper
{
    public class EspecialidadeProfile : Profile
    {
        public EspecialidadeProfile()
        {
            CreateMap<EspecialidadeDto, Especialidade>()
                .ReverseMap();
        }
    }
}
