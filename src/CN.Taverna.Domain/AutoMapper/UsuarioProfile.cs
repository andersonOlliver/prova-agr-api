using AutoMapper;
using CN.Taverna.Domain.Dto.Usuario;
using CN.Taverna.Domain.Entities.Usuario;

namespace CN.Taverna.Domain.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistraUsuarioDto, Usuario>();
            CreateMap<AtualizaUsuarioDto, Usuario>();
            CreateMap<Usuario, DetalhaUsuarioDto>();
            CreateMap<Usuario, ListaUsuarioDto>();
        }
    }
}
