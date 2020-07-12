using TaxaJuros.Unit.Tests.Dominio.Stubs;
using Xunit;

namespace TaxaJuros.Unit.Tests.Dominio.VOs
{
    public class TaxaJurosTests
    {
        private readonly Api.Dominio.VOs.TaxaJuros _taxa;

        public TaxaJurosTests()
        {
            _taxa = new Api.Dominio.VOs.TaxaJuros(1);
        }

        [Theory]
        [MemberData(nameof(StubsTaxasJuros.TaxasJurosComRetorno), MemberType = typeof(StubsTaxasJuros))]
        public void AoComararComOutroObjeto_DeveRetornarOValorEsperadoDeAcordoComATaxa(Api.Dominio.VOs.TaxaJuros taxaJuros,
            bool resultadoEsperado)
        {
            var resultado = _taxa.Equals(taxaJuros);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void AoCriarUmObjeto_DeveSerPossivelLerSeuValor()
        {
            const int VALOR_ESPERADO = 1;
            Assert.Equal(VALOR_ESPERADO, _taxa.Valor);
        }
    }
}
