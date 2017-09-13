using ReceitasCulinarias.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization;

namespace ReceitasCulinarias.Dal
{
	public class TipoReceitaDal
	{
		private MongoDBContext _context;
		private string collection;
		public TipoReceitaDal(MongoDBContext context)
		{
			_context = context;
			collection = "TipoReceita";
		}

		public IEnumerable<TipoReceita> Listar()
		{
			return _context.Database.GetCollection<TipoReceita>(collection).Find(x => true).ToList();
		}

		public void Cadastrar(TipoReceita tipoReceita)
		{
			_context.Database.GetCollection<TipoReceita>(collection).InsertOne(tipoReceita);
		}

	}
}
