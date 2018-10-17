using System;
using CN.Taverna.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace CN.Taverna.Domain.Entities.Usuario
{
    public class Usuario : ModelBase
    {
        [BsonRequired()]
        public string Nome { get; set; }

        [BsonRequired()]
        public string Email { get; set; }

        public byte[] HashSenha { get; set; }
        public byte[] SaltSenha { get; set; }

        public GeneroEnum Genero { get; set; }
        

        [BsonRequired()]
        public bool AceitaNotificacao { get; set; } = false;

        [BsonRequired()]
        public DateTime UltimoAcesso { get; set; } = DateTime.Now;
        

    }
}
