using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace API.Controllers
{
    /// <summary>
    /// Apenas para estudar sobre requisições asyncronas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController() { }

        [HttpGet]
        [Route("ExecutarUmPorVez")]
        public async Task<IActionResult> ExecutarUmPorVez()
        {
            StringBuilder resultado = new StringBuilder();
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();

            resultado.AppendLine("Iniciando processamento um por vez...");

            await RequisicaoUm(resultado);
            await RequisicaoDois(resultado);

            resultado.AppendLine("Agora que Requisição 1 e Requisição 2 finalizaram, pode fazer as demais tarefas.");
            await Task.Delay(1000);
            cronometro.Stop();
            resultado.AppendLine($"Demais tarefas finalizadas. Tempo total em segundos: {cronometro.Elapsed.TotalSeconds}");
            return Ok(resultado.ToString());
        }

        [HttpGet]
        [Route("ExecutarEmParalelo")]
        public async Task<IActionResult> ExecutarEmParalelo()
        {
            StringBuilder resultado = new StringBuilder();
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();

            resultado.AppendLine("Iniciando processamento em paralelo...");

            await Task.WhenAll(RequisicaoUm(resultado), RequisicaoDois(resultado));

            resultado.AppendLine("Agora que Requisição 1 e Requisição 2 finalizaram, pode fazer as demais tarefas.");
            await Task.Delay(1000);
            cronometro.Stop();
            resultado.AppendLine($"Demais tarefas finalizadas. Tempo total em segundos: {cronometro.Elapsed.TotalSeconds}");
            return Ok(resultado.ToString());
        }

        private async Task RequisicaoUm(StringBuilder resultado)
        {
            int numeroRequisicao = 1;
            resultado.AppendLine($"Iniciando requisição {numeroRequisicao} ...");
            await Task.Delay(1000);
            resultado.AppendLine($"Requisição {numeroRequisicao} iniciada...");
            await Task.Delay(2000);
            resultado.AppendLine($"Requisição {numeroRequisicao} processando...");
            await Task.Delay(4000);
            resultado.AppendLine($"Requisição {numeroRequisicao} finalizada...");
        }

        private async Task RequisicaoDois(StringBuilder resultado)
        {
            int numeroRequisicao = 2;
            resultado.AppendLine($"Iniciando requisição {numeroRequisicao} ...");
            await Task.Delay(500);
            resultado.AppendLine($"Requisição {numeroRequisicao} iniciada...");
            await Task.Delay(1000);
            resultado.AppendLine($"Requisição {numeroRequisicao} processando...");
            await Task.Delay(6000);
            resultado.AppendLine($"Requisição {numeroRequisicao} finalizada...");
        }

    }
}
