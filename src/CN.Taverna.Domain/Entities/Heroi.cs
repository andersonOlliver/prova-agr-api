using CN.Taverna.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CN.Taverna.Domain.Entities
{
    public class Heroi : ModelBase
    {
        [BsonRequired]
        public string UsuarioId { get; set; }

        [BsonRequired]
        public string Nome { get; set; }
        public int Poder { get; set; } = 10;
        public GeneroEnum Genero { get; set; }
        public int Experiencia { get; set; } = 10;
        public Especialidade Especialidade { get; set; }
        public int NivelAtual { get; set; } = 1;

        public Heroi ObterMelhorStatus(Heroi outro)
        {
            if (Poder >= outro.Poder)
                return this;
            return outro;
        }

    }
}
