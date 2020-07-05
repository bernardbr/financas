namespace CalculaJuros.Core.Dominio.VOs
{
    public class CodigoFonte
    {
        public string UrlCodigoFonte { get; private set; }

        public CodigoFonte(string urlCodigoFonte)
        {
            UrlCodigoFonte = urlCodigoFonte;
        }

        public override string ToString() => $"URL: {UrlCodigoFonte}";

        public override int GetHashCode() => UrlCodigoFonte.GetHashCode();

        public override bool Equals(object obj)        
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            var outro = obj as CodigoFonte;

            return UrlCodigoFonte.Equals(outro.UrlCodigoFonte);
        }
    }
}