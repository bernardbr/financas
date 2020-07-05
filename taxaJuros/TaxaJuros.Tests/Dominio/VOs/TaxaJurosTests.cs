namespace TaxaJuros.Tests.Dominio.VOs
{
    using TaxaJuros.Core.Dominio.VOs;
    using TaxaJuros.Tests.Dominio.Stubs;
    using Xunit;

    public class TaxaJurosTests
    {
        private TaxaJuros _taxa;

        public TaxaJurosTests()
        {
            _taxa = new TaxaJuros(1);
        }

        [Fact]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor()
        {
            var valorEsperado = 1;
            Assert.Equal(valorEsperado, _taxa.Valor);
        }

        [Theory]
        [MemberData(
            nameof(StubsTaxasJuros.TaxasJurosComRetorno), 
            MemberType = typeof(StubsTaxasJuros))]
        public void AoComararComOutroObjeto_DeveRetornarOValorEsperadoDeAcordoComATaxa(TaxaJuros taxaJuros, 
            bool resultadoEsperado)
        {
            var resultado = _taxa.Equals(taxaJuros);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}