using System;
using System.Collections.Generic;
using System.Text;
using CN.Taverna.Domain.Enums;

namespace CN.Taverna.Domain.Dto.Batalha
{
    public class HeroiBatalhaDto
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public int Poder { get; set; }
        public GeneroEnum Genero { get; set; }
        public int Experiencia { get; set; }
        public int NivelAtual { get; set; }
    }
}
