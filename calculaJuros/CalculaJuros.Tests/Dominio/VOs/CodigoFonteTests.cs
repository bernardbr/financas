namespace CalculaJuros.Tests.Dominio.VOs
{
    using CalculaJuros.Core.Dominio.VOs;
    using CalculaJuros.Tests.Stubs;
    using Xunit;
    
    public class CodigoFonteTests
    {
        private const string UrlPadrao = "http://www.meucodigo.com/source";
        private CodigoFonte _codigo;

        public CodigoFonteTests()
        {
            _codigo = new CodigoFonte(UrlPadrao);
        }

        [Theory]
        [InlineData(UrlPadrao)]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor(string urlEsperada)
        {
            Assert.Equal(urlEsperada, _codigo.UrlCodigoFonte);
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
    }
}