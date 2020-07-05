namespace CalculaJuros.Core.Dominio.VOs
{
    using Flunt.Notifications;
    using Flunt.Validations;

    public class JurosCompostos : Notifiable
    {
        public double ValorInicial { get; private set; }
        public double TaxaJuros { get; private set; }
        public int Meses { get; private set; }

        public JurosCompostos(double valorInicial, double taxaJuros, int meses)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            Meses = meses;

            AddNotifications(new Contract()
                .IsGreaterOrEqualsThan(
                    Meses, 0, "Meses", "É preciso informar os meses para cálculo dos juros"));
        }

        public override string ToString() => 
            $"Valor Inicial: {ValorInicial}; TaxaJuros: {TaxaJuros}; Meses: {Meses}";

        public override int GetHashCode() => 
            ValorInicial.GetHashCode() ^ TaxaJuros.GetHashCode() ^ Meses.GetHashCode();

        public override bool Equals(object obj)        
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            var outro = obj as JurosCompostos;

            return 
                ValorInicial.Equals(outro.ValorInicial) &&
                TaxaJuros.Equals(outro.TaxaJuros) &&
                Meses.Equals(outro.Meses);
        }
    }
}