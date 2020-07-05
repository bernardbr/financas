namespace TaxaJuros.Core.Dominio.VOs
{
    public class TaxaJuros
    {
        public double Valor { get; private set; }

        public TaxaJuros(double valor)
        {
            Valor = valor;
        }

        public override string ToString() => Valor.ToString();

        public override int GetHashCode() => Valor.GetHashCode();

        public override bool Equals(object obj)        
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            var outro = obj as TaxaJuros;
            return Valor.Equals(outro.Valor);            
        }
    }
}