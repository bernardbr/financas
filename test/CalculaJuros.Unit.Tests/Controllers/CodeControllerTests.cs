using CalculaJuros.Api.Contratos;
using CalculaJuros.Api.Controllers;
using CalculaJuros.Api.Dominio.Servicos.Interfaces;
using CalculaJuros.Api.Dominio.VOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace CalculaJuros.Unit.Tests.Controllers
{
    public class CodeControllerTests
    {
        private readonly CodeController _controller;
        private readonly Mock<IServicoCodigo> _mockServico;

        public CodeControllerTests()
        {
            var mockLogger = new Mock<ILogger<CodeController>>(MockBehavior.Loose);
            _mockServico = new Mock<IServicoCodigo>(MockBehavior.Strict);
            _controller = new CodeController(mockLogger.Object, _mockServico.Object);
        }

        [Fact]
        public void AoRealizarGET_DeveRetornar500SeAConsultaFalhar()
        {
            const int RETORNO_ESPERADO = 500;
            _mockServico.Setup(x => x.ObterCodigoFonte()).Throws(new Exception("Erro inesperado!"));

            var actionResult = _controller.ObterUrlCodigo();
            var internalServerError = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(RETORNO_ESPERADO, internalServerError.StatusCode);

            _mockServico.Verify();
        }

        [Theory]
        [InlineData("http://www.meucodigo.com/")]
        public void AoRealizarGET_DeveRetornarURLDoCodigo(string urlEsperada)
        {
            _mockServico.Setup(x => x.ObterCodigoFonte()).Returns(new CodigoFonte(urlEsperada));

            var actionResult = _controller.ObterUrlCodigo();
            var ok = Assert.IsType<OkObjectResult>(actionResult);
            var code = Assert.IsAssignableFrom<ContratoRetornoShowCode>(ok.Value);

            Assert.Equal(urlEsperada, code.UrlProjeto);

            _mockServico.Verify();
        }
    }
}
