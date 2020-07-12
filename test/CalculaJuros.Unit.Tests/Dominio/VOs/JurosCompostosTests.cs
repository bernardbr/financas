using CalculaJuros.Api.Dominio.VOs;
using CalculaJuros.Unit.Tests.Stubs;
using Xunit;

namespace CalculaJuros.Unit.Tests.Dominio.VOs
{
    public class JurosCompostosTests
    {
        private const int MESES_PADRAO = 3;
        private const double TAXA_PADRAO = 2;
        private const double VALOR_PADRAO = 1;
        private readonly JurosCompostos _juros;

        public JurosCompostosTests()
        {
            _juros = new JurosCompostos(VALOR_PADRAO, TAXA_PADRAO, MESES_PADRAO);
        }

        [Theory]
        [MemberData(
            nameof(StubsJurosCompostos.JurosCompostosParaComparacao),
            MemberType = typeof(StubsJurosCompostos))]
        public void AoCompararComOutroObjeto_DeveRetornarOValorEsperadoDeAcordoComOsValores(
            JurosCompostos jurosCompostos, bool resultadoEsperado)
        {
            var resultado = _juros.Equals(jurosCompostos);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(VALOR_PADRAO, TAXA_PADRAO)]
        public void AoCriarUmObjeto_ComMesesMenorQueZero_DeveSinalizarQueOObjetoEInvalido(double valorInicialEsperado,
            double taxaEsperada)
        {
            var juros = new JurosCompostos(valorInicialEsperado, taxaEsperada, -1);
            Assert.False(juros.Valid);
        }

        [Theory]
        [InlineData(VALOR_PADRAO, TAXA_PADRAO, MESES_PADRAO)]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor(double valorInicialEsperado,
            double taxaEsperada, int mesesEsperados)
        {
            Assert.Equal(valorInicialEsperado, _juros.ValorInicial);
            Assert.Equal(taxaEsperada, _juros.TaxaJuros);
            Assert.Equal(mesesEsperados, _juros.Meses);
            Assert.True(_juros.Valid);
        }
    }
}
