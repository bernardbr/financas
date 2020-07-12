using CalculaJuros.Api.Dominio.VOs;
using CalculaJuros.Unit.Tests.Stubs;
using Xunit;

namespace CalculaJuros.Unit.Tests.Dominio.VOs
{
    public class CodigoFonteTests
    {
        private const string URL_PADRAO = "http://www.meucodigo.com/source";
        private readonly CodigoFonte _codigo;

        public CodigoFonteTests()
        {
            _codigo = new CodigoFonte(URL_PADRAO);
        }

        [Theory]
        [MemberData(
            nameof(StubsCodigoFonte.CodigosParaComparacao),
            MemberType = typeof(StubsCodigoFonte))]
        public void AoComararComOutroObjeto_DeveRetornarOValorEsperadoDeAcordoComOsValores(
            CodigoFonte jurosCompostos, bool resultadoEsperado)
        {
            var resultado = _codigo.Equals(jurosCompostos);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(URL_PADRAO)]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor(string urlEsperada)
        {
            Assert.Equal(urlEsperada, _codigo.UrlCodigoFonte);
        }
    }
}
