using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CN.Taverna.Domain.Dto.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CN.Taverna.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CN.Taverna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var usuarioSalvo = await _usuarioService.Autenticar(login);

            if (usuarioSalvo == null)
                return Unauthorized();

            var tokenString = GerarToken(usuarioSalvo);

            return Ok(new { tokenString });
        }
        
        [HttpPost("registrar")]
        public async Task<IActionResult> Create([FromBody] RegistraUsuarioDto usuario)
        {
            var resultado = await _usuarioService.Inserir(usuario);
            return Ok(resultado);
        }

        private string GerarToken(DetalhaUsuarioDto usuarioSalvo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, usuarioSalvo.Id),
                    new Claim(ClaimTypes.Email, usuarioSalvo.Email),
                    new Claim(ClaimTypes.Name, usuarioSalvo.Nome)
                }),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}