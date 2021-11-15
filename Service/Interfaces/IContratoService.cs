using Core.Models;

namespace Service.Interfaces
{
    public interface IContratoService
    {
        Task<IEnumerable<Contrato>> ObterTodos();

        Task<Contrato> Adicionar(Contrato contrato);

        Task Deletar(int numero);

        Task AtualizarValorContrato(Contrato contrato);
    }
}
