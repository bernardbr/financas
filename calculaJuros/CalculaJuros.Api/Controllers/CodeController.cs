namespace CalculaJuros.Api.Controllers
{
    using System;
    using CalculaJuros.Api.Contratos;
    using CalculaJuros.Api.Logging;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/v1/showmethecode")]
    public class CodeController : ControllerBase
    {
        private readonly ILogger<CodeController> _logger;
        private readonly IServicoCodigo _servico;

        public CodeController(ILogger<CodeController> logger, IServicoCodigo servico)
        {
            _logger = logger;
            _servico = servico;
        }

        /// <summary>
        /// Obtém a URL no Github onde estão hospedados os fontes da solução.
        /// </summary>
        /// <returns>A URL no Github.</returns>
        /// <response code="200">URL obtida com sucesso</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet]        
        public IActionResult ObterUrlCodigo()
        {
            try
            {
                var url = _servico.ObterCodigoFonte().UrlCodigoFonte;
                var retorno = new ContratoRetornoShowCode { UrlProjeto = url };
                return Ok(retorno);
            }
            catch (Exception e)
            {
                _logger.LogError(LogEventosApi.ErroAoObterUrlCodigo, e, 
                    "Erro ao obter url do código");                              
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Houve uma falha inesperada na requisição: {e.Message}");
            }
        }
    }
}