using CN.Taverna.Domain.Enums;
using System;

namespace CN.Taverna.Domain.Entities.Batalha
{
    public class Heroi
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
