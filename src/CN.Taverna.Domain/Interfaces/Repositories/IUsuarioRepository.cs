using System.Threading.Tasks;
using CN.Taverna.Domain.Entities.Usuario;

namespace CN.Taverna.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterPorEmail(string email);
        
    }
}