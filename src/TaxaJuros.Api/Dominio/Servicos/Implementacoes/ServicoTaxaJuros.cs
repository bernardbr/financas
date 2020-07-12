namespace TaxaJuros.Api.Dominio.Servicos.Implementacoes
{
    public class ServicoTaxaJuros : IServicoTaxaJuros
    {
        private static readonly VOs.TaxaJuros _taxaPadrao = new VOs.TaxaJuros(0.01);

        public VOs.TaxaJuros ObterTaxaJuros()
        {
            return _taxaPadrao;
        }
    }
}
