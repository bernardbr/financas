using Flunt.Notifications;
using Flunt.Validations;

namespace CalculaJuros.Api.Dominio.VOs
{
    public class JurosCompostos : Notifiable
    {
        public JurosCompostos(double valorInicial, double taxaJuros, int meses)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            Meses = meses;

            AddNotifications(new Contract()
                .IsGreaterOrEqualsThan(
                    Meses, 0, "Meses", "É preciso informar os meses para cálculo dos juros"));
        }

        public int Meses { get; }
        public double TaxaJuros { get; }
        public double ValorInicial { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var outro = obj as JurosCompostos;

            return
                ValorInicial.Equals(outro?.ValorInicial) &&
                TaxaJuros.Equals(outro?.TaxaJuros) &&
                Meses.Equals(outro?.Meses);
        }

        public override int GetHashCode()
        {
            return ValorInicial.GetHashCode() ^ TaxaJuros.GetHashCode() ^ Meses.GetHashCode();
        }

        public override string ToString()
        {
            return $"Valor Inicial: {ValorInicial}; TaxaJuros: {TaxaJuros}; Meses: {Meses}";
        }
    }
}
