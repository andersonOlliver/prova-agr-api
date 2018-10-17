using CN.Taverna.Domain.Enums;
using System;

namespace CN.Taverna.Domain.Dto.Heroi
{
    public class DetalhaHeroiDto : HeroiDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Poder { get; set; }
        public GeneroEnum Genero { get; set; }
        public int Experiencia { get; set; }
        public int NivelAtual { get; set; }
        public DateTime DataCriacao { get; set; } 
    }
}
