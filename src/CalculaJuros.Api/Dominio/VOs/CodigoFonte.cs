namespace CalculaJuros.Api.Dominio.VOs
{
    public class CodigoFonte
    {
        public CodigoFonte(string urlCodigoFonte)
        {
            UrlCodigoFonte = urlCodigoFonte;
        }

        public string UrlCodigoFonte { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var outro = obj as CodigoFonte;

            return UrlCodigoFonte.Equals(outro?.UrlCodigoFonte);
        }

        public override int GetHashCode()
        {
            return UrlCodigoFonte.GetHashCode();
        }

        public override string ToString()
        {
            return $"URL: {UrlCodigoFonte}";
        }
    }
}
