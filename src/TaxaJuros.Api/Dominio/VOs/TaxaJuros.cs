using System.Globalization;

namespace TaxaJuros.Api.Dominio.VOs
{
    public class TaxaJuros
    {
        public TaxaJuros(double valor)
        {
            Valor = valor;
        }

        public double Valor { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var outro = obj as TaxaJuros;
            return Valor.Equals(outro?.Valor);
        }

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }

        public override string ToString()
        {
            return Valor.ToString(CultureInfo.InvariantCulture);
        }
    }
}
