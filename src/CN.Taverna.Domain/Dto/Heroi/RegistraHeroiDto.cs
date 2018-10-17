using CN.Taverna.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CN.Taverna.Domain.Dto.Heroi
{
    public class RegistraHeroiDto : HeroiDto
    {
        public string UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public GeneroEnum Genero { get; set; }
        public int NivelAtual { get; set; }
        public int? Poder { get; set; }
        public int? Experiencia { get; set; }
    }
}
