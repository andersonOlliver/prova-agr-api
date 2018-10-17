using System.Collections.Generic;
using System.Threading.Tasks;
using CN.Taverna.Domain.Entities;

namespace CN.Taverna.Domain.Interfaces.Repositories
{
    public interface IRepository<TModel> where TModel: ModelBase
    {
        Task<TModel> Atualizar(TModel objeto);
        Task<TModel> Inserir(TModel objeto);
        Task<TModel> ObterPorIdAsync(string id);
        Task<IEnumerable<TModel>> ObterTodos();
        Task RemoverAsync(TModel objeto);
    }
}
