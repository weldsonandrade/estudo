using Data.Interfaces.Repository;
using Core.Models;
using Service.Interfaces;
using Core.Exceptions;

namespace Service.Implementations
{
    public class ContratoServices : IContratoService
    {
        private readonly IContratoRepository _contratos;

        public ContratoServices(IContratoRepository contratoRepository)
        {
            _contratos = contratoRepository;
        }

        public async Task<Contrato> Adicionar(Contrato contrato) => await _contratos.Adicionar(contrato);

        public async Task AtualizarValorContrato(Contrato contrato)
        {
            long documentosAtualizados = await _contratos.AtualizarValorContrato(contrato);
            LancarExcecaoSeNaoEncontrarDocumentos(documentosAtualizados);
        }

        public async Task Deletar(int numero)
        {
            long documentosDeletados = await _contratos.Deletar(numero);
            LancarExcecaoSeNaoEncontrarDocumentos(documentosDeletados);
        }

        private void LancarExcecaoSeNaoEncontrarDocumentos(long documentosDeletados)
        {
            if (documentosDeletados == 0)
                throw new DocumentoNaoEncontratoException();
        }

        public Task<IEnumerable<Contrato>> ObterTodos() => _contratos.ObterTodos();
    }
}
