using CN.Taverna.Domain.Dto.Usuario;
using CN.Taverna.Domain.Entities.Usuario;
using System.Threading.Tasks;

namespace CN.Taverna.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto, Usuario>
    {
        Task<DetalhaUsuarioDto> Inserir(RegistraUsuarioDto registraUsuarioDto);
        Task<DetalhaUsuarioDto> Autenticar(LoginDto loginDto);
    }
}