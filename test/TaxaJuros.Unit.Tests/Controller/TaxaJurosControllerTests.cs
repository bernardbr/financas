using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using TaxaJuros.Api.Contratos;
using TaxaJuros.Api.Controllers;
using TaxaJuros.Api.Dominio.Servicos;
using Xunit;

namespace TaxaJuros.Unit.Tests.Controller
{
    public class TaxaJurosControllerTests
    {
        private const double TAXA_JUROS_PADRAO = 0.1;

        private readonly TaxaJurosController _controller;
        private readonly Mock<IServicoTaxaJuros> _serviceMock;

        public TaxaJurosControllerTests()
        {
            var loggerMock = new Mock<ILogger<TaxaJurosController>>();
            _serviceMock = new Mock<IServicoTaxaJuros>();
            _controller = new TaxaJurosController(loggerMock.Object, _serviceMock.Object);
        }

        [Fact]
        public void AoRealizarGET_DeveObterOContratoDeRetornoComOsJuros()
        {
            _serviceMock.Setup(x => x.ObterTaxaJuros()).Returns(new Api.Dominio.VOs.TaxaJuros(TAXA_JUROS_PADRAO));

            var actionResult = _controller.ObterTaxaDeJuros();
            var ok = Assert.IsType<OkObjectResult>(actionResult);
            var taxa = Assert.IsAssignableFrom<ContratoRetornoTaxaJuros>(ok.Value);

            Assert.Equal(TAXA_JUROS_PADRAO, taxa.TaxaJuros);

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
