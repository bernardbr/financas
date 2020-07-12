using CalculaJuros.Api.Clients;
using CalculaJuros.Api.Contratos;
using CalculaJuros.Api.Controllers;
using CalculaJuros.Api.Dominio.Servicos.Interfaces;
using CalculaJuros.Api.Dominio.VOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Polly.CircuitBreaker;
using System;
using Xunit;

namespace CalculaJuros.Unit.Tests.Controllers
{
    public class CalculoJurosControllerTests
    {
        private const int MESES_PADRAO = 1;

        private const double MONTANTE_PADRAO = 1.1;

        private const double TAXA_JUROS_PADRAO = 0.1;

        private const double VALOR_INICIAL_PADRAO = 1;

        private static readonly JurosCompostos _jurosCompostosPadrao;

        private readonly CalculoJurosController _controller;

        private readonly Mock<IServicoCalculoJurosCompostos> _mockServicoCalculoJuros;

        private readonly Mock<ITaxaJurosClient> _mockTaxaJurosClient;

        static CalculoJurosControllerTests()
        {
            _jurosCompostosPadrao = new JurosCompostos(VALOR_INICIAL_PADRAO, TAXA_JUROS_PADRAO, MESES_PADRAO);
        }

        public CalculoJurosControllerTests()
        {
            var mockLogger = new Mock<ILogger<CalculoJurosController>>(MockBehavior.Loose);
            _mockServicoCalculoJuros = new Mock<IServicoCalculoJurosCompostos>(MockBehavior.Strict);
            _mockTaxaJurosClient = new Mock<ITaxaJurosClient>(MockBehavior.Strict);
            _controller = new CalculoJurosController(
                mockLogger.Object,
                _mockServicoCalculoJuros.Object,
                _mockTaxaJurosClient.Object);
        }

        [Fact]
        public async void AoRealizarGET_ComCircuitoInterrompido_DeveFalharNoCalculoDoMontante()
        {
            const int RETORNO_ESPERADO = 503;
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).Throws(new BrokenCircuitException());

            var actionResult = await _controller.ObterMontante(VALOR_INICIAL_PADRAO, MESES_PADRAO);
            var serviceUnavaible = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(RETORNO_ESPERADO, serviceUnavaible.StatusCode);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }

        [Fact]
        public async void AoRealizarGET_ComTempoMenorQueZero_DeveFalharNoCalculoDoMontante()
        {
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TAXA_JUROS_PADRAO);

            var actionResult = await _controller.ObterMontante(VALOR_INICIAL_PADRAO, -1);
            Assert.IsType<BadRequestObjectResult>(actionResult);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }

        [Fact]
        public async void AoRealizarGET_DeveCalcularOMontanteComSucesso()
        {
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TAXA_JUROS_PADRAO);
            _mockServicoCalculoJuros.Setup(x => x.ApurarMontante(_jurosCompostosPadrao)).Returns(MONTANTE_PADRAO);

            var actionResult = await _controller.ObterMontante(VALOR_INICIAL_PADRAO, MESES_PADRAO);
            var ok = Assert.IsType<OkObjectResult>(actionResult);
            var resultado = Assert.IsAssignableFrom<ContratoRetornoMontanteJuros>(ok.Value);

            Assert.Equal(MONTANTE_PADRAO, resultado.Montante);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }

        [Fact]
        public async void AoRealizarGET_DeveRetornar500SeAConsultaFalhar()
        {
            const int RETORNO_ESPERADO = 500;

            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TAXA_JUROS_PADRAO);
            _mockServicoCalculoJuros.Setup(x => x.ApurarMontante(_jurosCompostosPadrao)).Throws(new Exception());

            var actionResult = await _controller.ObterMontante(VALOR_INICIAL_PADRAO, MESES_PADRAO);
            var internalServerError = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(RETORNO_ESPERADO, internalServerError.StatusCode);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }
    }
}
