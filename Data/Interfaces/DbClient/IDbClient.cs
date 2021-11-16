using MongoDB.Driver;
using Core.Models;

namespace Data.Interfaces.DbClient
{
    public interface IDbClient
    {
        IMongoCollection<Contrato> GetContratosCollection();
    }
}
