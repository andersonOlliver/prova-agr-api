using System;
using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CN.Taverna.Infra.Repository
{
    public class RepositoryBase<TCollection> : IRepository<TCollection> where TCollection : ModelBase
    {
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<TCollection> Collection { get; }

        public RepositoryBase(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TavernaDB");
            var client = new MongoClient(connectionString);

            this.Database = client.GetDatabase("TavernaDB");
            this.Collection = this.Database.GetCollection<TCollection>(typeof(TCollection).Name);
        }

        public async Task<TCollection> Inserir(TCollection objeto)
        {
            await Collection.InsertOneAsync(objeto);
            return objeto;
        }

        public async Task<IEnumerable<TCollection>> ObterTodos()
        {
            var results = await Collection.Find(_ => true).ToListAsync();
            return results;
        }

        public async Task<TCollection> Atualizar(TCollection objeto)
        {
            Expression<Func<TCollection, bool>> filter = x => x.Id.Equals(objeto.Id);
            var result = await Collection.ReplaceOneAsync(filter, objeto);

            return objeto;
        }

        public async Task<TCollection> ObterPorIdAsync(string id)
        {
            var filter = Builders<TCollection>.Filter.Eq(u => u.Id, id);
            var results = await Collection.Find(filter).SingleOrDefaultAsync();
            return results;
        }

        public async Task RemoverAsync(TCollection objeto)
        {
            var filter = Builders<TCollection>.Filter.Eq(u => u.Id, objeto.Id);
            await Collection.DeleteOneAsync(filter);
        }
    }
}
