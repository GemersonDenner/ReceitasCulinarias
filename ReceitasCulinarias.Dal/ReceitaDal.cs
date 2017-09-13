using MongoDB.Driver;
using ReceitasCulinarias.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceitasCulinarias.Dal
{
    public class ReceitaDal
    {
		private MongoDBContext _context;
		private string collection;
		public ReceitaDal(MongoDBContext context)
		{
			_context = context;
			collection = "Receita";
		}

		public IEnumerable<Receita> Listar()
		{
			return _context.Database.GetCollection<Receita>(collection).Find(x => true).ToList();
		}

		public void Cadastrar(Receita receita)
		{
			_context.Database.GetCollection<Receita>(collection).InsertOne(receita);
		}
	}
}
