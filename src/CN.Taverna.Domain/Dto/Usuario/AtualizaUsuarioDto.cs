using System;

namespace CN.Taverna.Domain.Dto.Usuario
{
    public class AtualizaUsuarioDto : UsuarioDto
    {
        public string Id { get; set; }
        public bool AceitaNotificacao { get; set; }
    }
}
