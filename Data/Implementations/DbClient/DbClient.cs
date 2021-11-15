using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Core.Models;
using Data.Interfaces.DbClient;

namespace Data.Implementations.DbClient
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Contrato> _contratos;

        public DbClient(IOptions<MongoDbConfig> mongoDbConfig)
        {
            var cliente = new MongoClient(mongoDbConfig.Value.Connection_String);
            var database = cliente.GetDatabase(mongoDbConfig.Value.Database_Name);
            _contratos = database.GetCollection<Contrato>(mongoDbConfig.Value.Contratos_Collection_Name);
        }

        public IMongoCollection<Contrato> GetContratosCollection() => _contratos;
    }
}
