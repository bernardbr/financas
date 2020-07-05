namespace CalculaJuros.Tests.Dominio.VOs
{
    using CalculaJuros.Core.Dominio.VOs;
    using CalculaJuros.Tests.Stubs;
    using Xunit;
    
    public class JurosCompostosTests
    {
        private const double ValorPadrao = 1;
        private const double TaxaPadrao = 2;
        private const int MesesPadrao = 3;

        private JurosCompostos _juros;

        public JurosCompostosTests()
        {
            _juros = new JurosCompostos(ValorPadrao, TaxaPadrao, MesesPadrao);
        }

        [Theory]
        [InlineData(ValorPadrao, TaxaPadrao, MesesPadrao)]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor(double valorInicialEsperado, 
            double taxaEsperada, int mesesEsperados)
        {
            Assert.Equal(valorInicialEsperado, _juros.ValorInicial);
            Assert.Equal(taxaEsperada, _juros.TaxaJuros);
            Assert.Equal(mesesEsperados, _juros.Meses);
            Assert.True(_juros.Valid);
        }

        [Theory]
        [InlineData(ValorPadrao, TaxaPadrao)]
        public void AoCriarUmObjeto_ComMesesMenorQueZero_DeveSinalizarQueOObjetoEInvalido(double valorInicialEsperado, 
            double taxaEsperada)
        {
            var juros = new JurosCompostos(valorInicialEsperado, taxaEsperada, -1);
            Assert.False(juros.Valid);
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
    }
}