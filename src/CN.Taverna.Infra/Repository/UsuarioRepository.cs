using CN.Taverna.Domain.Entities.Usuario;
using CN.Taverna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CN.Taverna.Infra.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration)
            : base(configuration) { }

        public async Task<Usuario> ObterPorEmail(string email)
        {

            var results = await Collection.Find(Builders<Usuario>.Filter.Eq("Email", email)).FirstOrDefaultAsync();
            return results;
        }
    }
}
