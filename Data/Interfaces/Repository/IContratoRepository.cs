using Core.Models;

namespace Data.Interfaces.Repository
{
    public interface IContratoRepository : IGenericRepository<Contrato>
    {
        /// <summary>
        /// Deleta contrato.
        /// </summary>
        /// <param name="numero">Número do contrato</param>
        /// <returns>Número de documentos deletedos</returns>
        Task<long> Deletar(int numero);

        Task<long> AtualizarValorContrato(Contrato contrato);
    }
}
