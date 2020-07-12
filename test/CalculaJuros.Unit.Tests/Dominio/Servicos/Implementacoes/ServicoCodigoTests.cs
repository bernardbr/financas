using CalculaJuros.Api.Dominio.Servicos.Implementacoes;
using Xunit;

namespace CalculaJuros.Unit.Tests.Dominio.Servicos.Implementacoes
{
    public class ServicoCodigoTests
    {
        private readonly ServicoCodigo _servico;

        public ServicoCodigoTests()
        {
            _servico = new ServicoCodigo();
        }

        [Theory]
        [InlineData("https://github.com/Rafael-Simonelli/financas")]
        public void APartirDoServico_DeveSerPossivelObterAURLDoCodigo(string urlEsperada)
        {
            var url = _servico.ObterCodigoFonte().UrlCodigoFonte;
            Assert.Equal(urlEsperada, url);
        }
    }
}
