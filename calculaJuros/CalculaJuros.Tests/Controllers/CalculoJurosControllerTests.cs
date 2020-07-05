namespace CalculaJuros.Tests.Controllers
{
    using System;
    using CalculaJuros.Api.Clients.Interfaces;
    using CalculaJuros.Api.Contratos;
    using CalculaJuros.Api.Controllers;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using CalculaJuros.Core.Dominio.VOs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Polly.CircuitBreaker;
    using Xunit;

    public class CalculoJurosControllerTests
    {
        private const double ValorInicialPadrao = 1;
        private const double TaxaJurosPadrao = 0.1;
        private const int MesesPadrao = 1;
        private const double MontantePadrao = 1.1;        

        private static readonly JurosCompostos JurosCompostosPadrao = 
            new JurosCompostos(ValorInicialPadrao, TaxaJurosPadrao, MesesPadrao);

        private Mock<ILogger<CalculoJurosController>> _mockLogger;
        private Mock<IServicoCalculoJurosCompostos> _mockServicoCalculoJuros;
        private Mock<ITaxaJurosClient> _mockTaxaJurosClient;
        private CalculoJurosController _controller;

        public CalculoJurosControllerTests()
        {
            _mockLogger = new Mock<ILogger<CalculoJurosController>>(MockBehavior.Loose);
            _mockServicoCalculoJuros = new Mock<IServicoCalculoJurosCompostos>(MockBehavior.Strict);
            _mockTaxaJurosClient = new Mock<ITaxaJurosClient>(MockBehavior.Strict);
            _controller = new CalculoJurosController(
                _mockLogger.Object, 
                _mockServicoCalculoJuros.Object, 
                _mockTaxaJurosClient.Object);
        }

        [Fact]
        public async void AoRealizarGET_ComTempoMenorQueZero_DeveFalharNoCalculoDoMontante()
        {
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TaxaJurosPadrao);
            
            var actionResult = await _controller.ObterMontante(ValorInicialPadrao, -1);
            var badRequest = Assert.IsType<BadRequestObjectResult>(actionResult);
            
            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }

        [Fact]
        public async void AoRealizarGET_ComCircuitoInterrompido_DeveFalharNoCalculoDoMontante()
        {
            var retornoEsperado = 503;            
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).Throws(new BrokenCircuitException());

            var actionResult = await _controller.ObterMontante(ValorInicialPadrao, MesesPadrao);
            var serviceUnavaible = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(retornoEsperado, serviceUnavaible.StatusCode);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }   

        [Fact] 
        public async void AoRealizarGET_DeveRetornar500SeAConsultaFalhar()
        {
            var retornoEsperado = 500;   
            
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TaxaJurosPadrao);
            _mockServicoCalculoJuros.Setup(x => x.ApurarMontante(JurosCompostosPadrao)).Throws(new Exception());

            var actionResult = await _controller.ObterMontante(ValorInicialPadrao, MesesPadrao);
            var internalServerError = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(retornoEsperado, internalServerError.StatusCode);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }

        [Fact]
        public async void AoRealizarGET_DeveCalcularOMontanteComSucesso()
        {
            _mockTaxaJurosClient.Setup(x => x.ObterTaxaJuros()).ReturnsAsync(TaxaJurosPadrao);
            _mockServicoCalculoJuros.Setup(x => x.ApurarMontante(JurosCompostosPadrao)).Returns(MontantePadrao);
            
            var actionResult = await _controller.ObterMontante(ValorInicialPadrao, MesesPadrao);
            var ok = Assert.IsType<OkObjectResult>(actionResult);
            var resultado = Assert.IsAssignableFrom<ContratoRetornoMontanteJuros>(ok.Value);

            Assert.Equal(MontantePadrao, resultado.Montante);

            _mockTaxaJurosClient.Verify();
            _mockServicoCalculoJuros.Verify();
        }               
    }
}