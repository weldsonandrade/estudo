using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
using Core.Exceptions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly ILogger<ContratoController> _logger;
        private readonly IContratoService _contratoService;

        public ContratoController(ILogger<ContratoController> logger, IContratoService contratoService)
        {
            _logger = logger;
            _contratoService = contratoService;
        }

        [HttpGet] 
        public Task<IEnumerable<Contrato>> Get()
        {
            return _contratoService.ObterTodos();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Contrato))]
        public IActionResult Post(Contrato contrato)
        {
            _contratoService.Adicionar(contrato);
            return Ok(contrato);
        }

        [HttpDelete]
        [Route("{numero:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int numero)
        {
            try
            {
                _contratoService.Deletar(numero);
                return NoContent();
            }
            catch (DocumentoNaoEncontratoException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{numero:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int numero, [FromBody] decimal valor)
        {
            try
            {
                await _contratoService.AtualizarValorContrato(new Contrato() { Numero = numero, Valor = valor });                
                return Ok();
            }
            catch (DocumentoNaoEncontratoException)
            {
                return NotFound();
            }
        }

    }
}
