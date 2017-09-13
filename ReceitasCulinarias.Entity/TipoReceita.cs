using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReceitasCulinarias.Entity
{
    public class TipoReceita
    {
		public ObjectId Id { get; set; }

		[BsonElement("titulo")]
		public string Titulo { get; set; }

		[BsonElement("descricao")]
		public string Descricao { get; set; }
	}
}
