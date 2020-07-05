namespace TaxaJuros.Core.Dominio.Servicos.Implementacoes
{
    using TaxaJuros.Core.Dominio.Servicos.Interfaces;
    using TaxaJuros.Core.Dominio.VOs;

    public class ServicoTaxaJuros : IServicoTaxaJuros
    {
        private static readonly TaxaJuros TaxaPadrao = new TaxaJuros(0.01);

        public TaxaJuros ObterTaxaJuros() => TaxaPadrao;
    }
}