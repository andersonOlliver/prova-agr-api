using System.Threading.Tasks;
using CN.Taverna.Domain.Dto.Batalha;
using CN.Taverna.Domain.Entities.Batalha;

namespace CN.Taverna.Domain.Interfaces.Services
{
    public interface IBatalhaService : IService<BatalhaDto, Batalha>
    {
        Task<BatalhaDto> EfetuarBatalhaAsync(PedidoBatalhaDto pedidoBatalhaDto);
    }
}