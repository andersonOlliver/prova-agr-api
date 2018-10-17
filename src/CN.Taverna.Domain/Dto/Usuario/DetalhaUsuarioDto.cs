using System;

namespace CN.Taverna.Domain.Dto.Usuario
{
    public class DetalhaUsuarioDto : UsuarioDto
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool AceitaNotificacao { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}