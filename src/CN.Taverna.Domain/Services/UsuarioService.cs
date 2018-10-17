using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CN.Taverna.Domain.Dto.Heroi;
using CN.Taverna.Domain.Dto.Usuario;
using CN.Taverna.Domain.Entities.Usuario;
using CN.Taverna.Domain.Interfaces.Repositories;
using CN.Taverna.Domain.Interfaces.Services;

namespace CN.Taverna.Domain.Services
{
    public class UsuarioService : ServiceBase<UsuarioDto, Usuario> , IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<DetalhaUsuarioDto> Inserir(RegistraUsuarioDto registraUsuarioDto)
        {
            var usuario = Map(registraUsuarioDto);
            CreatePasswordHash(registraUsuarioDto.Senha, out var passwordHash, out var passwordSalt);

            usuario.SaltSenha = passwordSalt;
            usuario.HashSenha = passwordHash;

            usuario =  await _repository.Inserir(usuario);

            return Map<DetalhaUsuarioDto>(usuario);
        }

        public async Task<DetalhaUsuarioDto> Autenticar(LoginDto loginDto)
        {
            var usuario = await _repository.ObterPorEmail(loginDto.Email);

            if (usuario == null)
                return null;

            return VerifyPasswordHash(loginDto.Senha, usuario.HashSenha, usuario.SaltSenha) ? Map<DetalhaUsuarioDto>(usuario) : null;
        }
        

        #region Private methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}