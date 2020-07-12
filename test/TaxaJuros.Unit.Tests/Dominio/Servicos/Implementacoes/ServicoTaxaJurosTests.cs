using TaxaJuros.Api.Dominio.Servicos.Implementacoes;
using Xunit;

namespace TaxaJuros.Unit.Tests.Dominio.Servicos.Implementacoes
{
    public class ServicoTaxaJurosTests
    {
        private readonly ServicoTaxaJuros _servico;

        public ServicoTaxaJurosTests()
        {
            _servico = new ServicoTaxaJuros();
        }

        [Fact]
        public void APartirDoServico_TaxaDeJurosDeveSerUmPorCento()
        {
            const double JUROS_ESPERADOS = 0.01;
            var taxaJuros = _servico.ObterTaxaJuros();
            Assert.Equal(JUROS_ESPERADOS, taxaJuros.Valor);
        }
    }
}
