namespace TaxaJuros.Tests.Controller
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using TaxaJuros.Api.Contratos;
    using TaxaJuros.Api.Controllers;
    using TaxaJuros.Core.Dominio.Servicos.Interfaces;
    using TaxaJuros.Core.Dominio.VOs;
    using Xunit;

    public class TaxaJurosControllerTests
    {
        private const double TaxaJurosPadrao = 0.1;

        private Mock<ILogger<TaxaJurosController>> _loggerMock;
        private Mock<IServicoTaxaJuros> _serviceMock;
        private TaxaJurosController _controller;

        public TaxaJurosControllerTests()
        {
            _loggerMock = new Mock<ILogger<TaxaJurosController>>();
            _serviceMock = new Mock<IServicoTaxaJuros>();
            _controller = new TaxaJurosController(_loggerMock.Object, _serviceMock.Object);
        }

        [Fact]
        public void AoRealizarGET_DeveObterOContratoDeRetornoComOsJuros() 
        {
            _serviceMock.Setup(x => x.ObterTaxaJuros()).Returns(new TaxaJuros(TaxaJurosPadrao));

            var actionResult = _controller.ObterTaxaDeJuros();
            var ok = Assert.IsType<OkObjectResult>(actionResult);
            var taxa = Assert.IsAssignableFrom<ContratoRetornoTaxaJuros>(ok.Value);

            Assert.Equal(TaxaJurosPadrao, taxa.TaxaJuros);

            _serviceMock.Verify();
        }

        [Fact]
        public void AoRealizarGET_DeveRetornar500SeAConsultaFalhar()
        {
            var retornoEsperado = 500;
            _serviceMock.Setup(x => x.ObterTaxaJuros()).Throws(new Exception("Erro inesperado!"));

            var actionResult = _controller.ObterTaxaDeJuros();
            var internalServerError = Assert.IsType<ObjectResult>(actionResult);
            
            Assert.Equal(retornoEsperado, internalServerError.StatusCode);

            _serviceMock.Verify();
        }
    }
}