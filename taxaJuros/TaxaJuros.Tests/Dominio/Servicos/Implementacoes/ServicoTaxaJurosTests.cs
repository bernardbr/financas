namespace TaxaJuros.Tests.Dominio.Servicos.Implementacoes
{
    using TaxaJuros.Core.Dominio.Servicos.Implementacoes;
    using Xunit;

    public class ServicoTaxaJurosTests
    {
        private ServicoTaxaJuros _servico;

        public ServicoTaxaJurosTests()
        {
            _servico = new ServicoTaxaJuros();
        }

        [Fact]
        public void APartirDoServico_TaxaDeJurosDeveSerUmPorCento()
        {
            var jurosEsperados = 0.01;
            var taxaJuros = _servico.ObterTaxaJuros();
            Assert.Equal(jurosEsperados, taxaJuros.Valor);
        }
    }
}