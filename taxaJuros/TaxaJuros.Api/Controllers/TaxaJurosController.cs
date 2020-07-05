namespace TaxaJuros.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TaxaJuros.Api.Contratos;
    using TaxaJuros.Api.Logging;
    using TaxaJuros.Core.Dominio.Servicos.Interfaces;

    [ApiController]
    [Route("api/v1/taxaJuros")] 
    public class TaxaJurosController : ControllerBase
    {
        private readonly ILogger<TaxaJurosController> _logger;

        private readonly IServicoTaxaJuros _servico;
        
        public TaxaJurosController(ILogger<TaxaJurosController> logger, IServicoTaxaJuros servico)
        {
            _logger = logger;
            _servico = servico;
        }

        /// <summary>
        /// Obtém a taxa de juros padrão da aplicação. 
        /// </summary>
        /// <returns>A taxa de juros.</returns>
        /// <response code="200">Taxa de juros obtida com sucesso</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet]
        public IActionResult ObterTaxaDeJuros()
        {
            try            
            {
                var taxaJuros = _servico.ObterTaxaJuros().Valor;
                var retorno = new ContratoRetornoTaxaJuros { TaxaJuros = taxaJuros };
                return Ok(retorno);
            }
            catch (Exception e)
            {
                _logger.LogError(LogEventosApi.ErroAoObterTaxaJuros, e, "Erro ao obter taxa de juros");                              
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Houve uma falha inesperada na requisição: {e.Message}");
            }        
        }
    }
}