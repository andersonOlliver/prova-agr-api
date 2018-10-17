using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CN.Taverna.Domain.Entities
{
    public class ModelBase
    {
        [BsonId()]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
