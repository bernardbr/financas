namespace CalculaJuros.Tests.Controllers
{
    using System;
    using CalculaJuros.Api.Contratos;
    using CalculaJuros.Api.Controllers;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using CalculaJuros.Core.Dominio.VOs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class CodeControllerTests
    {
        private Mock<ILogger<CodeController>> _mockLogger;
        private Mock<IServicoCodigo> _mockServico;
        private CodeController _controller;

        public CodeControllerTests()
        {
            _mockLogger = new Mock<ILogger<CodeController>>(MockBehavior.Loose);
            _mockServico = new Mock<IServicoCodigo>(MockBehavior.Strict);
            _controller = new CodeController(_mockLogger.Object, _mockServico.Object);
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

        [Fact]
        public void AoRealizarGET_DeveRetornar500SeAConsultaFalhar()
        {
            var retornoEsperado = 500;
            _mockServico.Setup(x => x.ObterCodigoFonte()).Throws(new Exception("Erro inesperado!"));

            var actionResult = _controller.ObterUrlCodigo();
            var internalServerError = Assert.IsType<ObjectResult>(actionResult);

            Assert.Equal(retornoEsperado, internalServerError.StatusCode);

            _mockServico.Verify();
        }
    }
}