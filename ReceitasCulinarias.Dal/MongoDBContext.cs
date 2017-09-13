using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace ReceitasCulinarias.Dal
{
    public class MongoDBContext
	{
		private readonly IMongoClient _client;
		private readonly IMongoDatabase _database;

		public MongoDBContext(string conn, string dbName)
		{
			_client = new MongoClient(conn);
			_database = _client.GetDatabase(dbName);
		}

		public IMongoClient Client
		{
			get { return _client; }
		}

		public IMongoDatabase Database
		{
			get { return _database; }
		}

	}
}
