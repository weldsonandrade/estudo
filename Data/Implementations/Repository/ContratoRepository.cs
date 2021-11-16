using Core.Models;
using Data.Interfaces.DbClient;
using Data.Interfaces.Repository;
using MongoDB.Driver;

namespace Data.Implementations.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly IDbClient _dbClient;

        public ContratoRepository(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<Contrato> Adicionar(Contrato entity)
        {
            await _dbClient.GetContratosCollection().InsertOneAsync(entity);
            return entity;
        }

        public async Task<long> AtualizarValorContrato(Contrato contrato)
        {
            var filter = FiltroPorNumero(contrato.Numero);
            var alterar = Builders<Contrato>.Update.Set(c => c.Valor, contrato.Valor);
            var updateResult = await _dbClient.GetContratosCollection().UpdateOneAsync(filter, alterar);
            return updateResult.ModifiedCount;
        }

        public async Task<long> Deletar(int numero)
        {
            FilterDefinition<Contrato> filter = FiltroPorNumero(numero);
            var deleteResult = await _dbClient.GetContratosCollection().DeleteOneAsync(filter);
            return deleteResult.DeletedCount;
        }

        private FilterDefinition<Contrato> FiltroPorNumero(int numero)
        {
            return Builders<Contrato>.Filter.Where(c => c.Numero == numero);
        }

        public async Task<IEnumerable<Contrato>> ObterTodos()
        {
            var contratos = await _dbClient.GetContratosCollection().FindAsync<Contrato>(filter: Builders<Contrato>.Filter.Empty);
            return await contratos.ToListAsync();
        }
    }
}
