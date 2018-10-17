using CN.Taverna.Domain.Dto.Batalha;
using CN.Taverna.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CN.Taverna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IBatalhaService _batalhaService;

        public BatalhaController(IBatalhaService batalhaService)
        {
            _batalhaService = batalhaService;
        }

        [HttpPost]
        public async Task<IActionResult> EfetuarBatalha([FromBody]PedidoBatalhaDto pedidoBatalhaDto)
        {
            var resultado = await _batalhaService.EfetuarBatalhaAsync(pedidoBatalhaDto);
            return Ok(resultado);
        }

    }
}