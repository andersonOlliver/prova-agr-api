using CN.Taverna.Domain.Dto.Heroi;
using CN.Taverna.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CN.Taverna.API.Controllers
{
    [Route("api/{idUsuario}/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IHeroiService _heroiService;

        public HeroiController(IHeroiService heroiService)
        {
            _heroiService = heroiService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovo(string idUsuario, [FromBody] RegistraHeroiDto registraHeroiDto)
        {
            registraHeroiDto.UsuarioId = idUsuario;
            var resultado = await _heroiService.Inserir<DetalhaHeroiDto>(registraHeroiDto);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var resultado = await _heroiService.ObterPorIdAsync<DetalhaHeroiDto>(id);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _heroiService.ObterTodos<DetalhaHeroiDto>();
            return Ok(resultado);
        }
    }
}