using CN.Taverna.Domain.Dto.Usuario;
using CN.Taverna.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CN.Taverna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CriarNovo([FromBody] RegistraUsuarioDto usuario)
        {
            var resultado = await _usuarioService.Inserir(usuario);
            return Ok(resultado);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var resultado = await _usuarioService.ObterPorIdAsync<DetalhaUsuarioDto>(id);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _usuarioService.ObterTodos<ListaUsuarioDto>();
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(string id, [FromBody] AtualizaUsuarioDto usuario)
        {
            var resultado = await _usuarioService.Atualizar<DetalhaUsuarioDto>(usuario);
            return Ok(resultado);
        }
    }
}