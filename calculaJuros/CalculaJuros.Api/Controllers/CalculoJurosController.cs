namespace CalculaJuros.Api.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CalculaJuros.Api.Clients.Interfaces;
    using CalculaJuros.Api.Contratos;
    using CalculaJuros.Api.Logging;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using CalculaJuros.Core.Dominio.VOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Polly.CircuitBreaker;

    [ApiController]
    [Route("api/v1/calculaJuros")]
    public class CalculoJurosController : ControllerBase
    {
        private readonly ILogger<CalculoJurosController> _logger;
        private readonly IServicoCalculoJurosCompostos _servicoCalculoJuros;
        private readonly ITaxaJurosClient _taxaJurosClient;

        public CalculoJurosController(
            ILogger<CalculoJurosController> logger,
            IServicoCalculoJurosCompostos servicoCalculoJuros,
            ITaxaJurosClient taxaJurosClient)
        {
            _logger = logger;
            _servicoCalculoJuros = servicoCalculoJuros;
            _taxaJurosClient = taxaJurosClient;
        }
        
        /// <summary>
        /// Obtém o valor de um montante a juros compostos 
        /// a partir de um valor inicial e dos meses de rendimento.
        /// </summary>
        /// <param name="valorInicial">O valor inicial. (double)</param>
        /// <param name="meses">Os meses (int - precisa ser maior ou igual a zero).</param>
        /// <returns>O valor inicial acrescido dos juros calculados.</returns>
        /// <response code="200">Montante calculado com sucesso</response>
        /// <response code="400">Dados informados para cálculo são inválidos</response>
        /// <response code="500">Erro interno no servidor</response>
        /// <response code="503">Circuito aberto</response>
        [HttpGet]
        public async Task<IActionResult> ObterMontante(
            double valorInicial, int meses)
        {
            try
            {
                var taxaJuros = await _taxaJurosClient.ObterTaxaJuros();                                    
                var jurosCompostos = new JurosCompostos(valorInicial, taxaJuros, meses);
                
                if (jurosCompostos.Invalid)
                {
                    return BadRequest(jurosCompostos.Notifications);                    
                }
                
                var montante = _servicoCalculoJuros.ApurarMontante(jurosCompostos);
                var retorno = new ContratoRetornoMontanteJuros { Montante = montante };
                return Ok(retorno);
            }
            catch (BrokenCircuitException e)
            {
                _logger.LogError(LogEventosApi.CircuitoInterrompidoAoCalcularMontanteFinal, e, 
                    "Erro ao calcular montante final");                              
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                    "A aplicação está indisponível no momento. (Circuito aberto)");
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(LogEventosApi.ErroAoObterTaxaJuros, e, 
                    "Erro ao calcular montante final");      
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Não foi possível obter a taxa de juros: {e.Message}");
            }
            catch (Exception e)
            {
                _logger.LogError(LogEventosApi.ErroAoCalcularMontanteFinal, e, 
                    "Erro ao calcular montante final");                              
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Houve uma falha inesperada na requisição: {e.Message}");
            }
        }
    }
}