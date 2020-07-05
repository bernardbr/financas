namespace CalculaJuros.Core.Dominio.Servicos.Implementacoes
{
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using CalculaJuros.Core.Dominio.VOs;
    
    public class ServicoCodigo : IServicoCodigo
    {
        private static readonly CodigoFonte CodigoFontePadrao = 
            new CodigoFonte("https://github.com/Rafael-Simonelli/financas");

        public CodigoFonte ObterCodigoFonte() => CodigoFontePadrao;
    }
}