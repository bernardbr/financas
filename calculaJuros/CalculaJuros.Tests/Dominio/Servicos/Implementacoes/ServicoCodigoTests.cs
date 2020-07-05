namespace CalculaJuros.Tests.Dominio.Servicos.Implementacoes
{
    using CalculaJuros.Core.Dominio.Servicos.Implementacoes;
    using Xunit;

    public class ServicoCodigoTests
    {
        private ServicoCodigo _servico;

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