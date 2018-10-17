using CN.Taverna.Domain.Enums;

namespace CN.Taverna.Domain.Dto.Usuario
{
    public class RegistraUsuarioDto : UsuarioDto
    {
        public string Senha { get; set; }
        public GeneroEnum Genero { get; set; }
        public bool AceitaNotificacao { get; set; }
    }
}
