using CalculaJuros.Api.Dominio.Servicos.Interfaces;
using CalculaJuros.Api.Dominio.VOs;

namespace CalculaJuros.Api.Dominio.Servicos.Implementacoes
{
    public class ServicoCodigo : IServicoCodigo
    {
        private static readonly CodigoFonte _codigoFontePadrao;

        static ServicoCodigo()
        {
            _codigoFontePadrao = new CodigoFonte("https://github.com/Rafael-Simonelli/financas");
        }

        public CodigoFonte ObterCodigoFonte()
        {
            return _codigoFontePadrao;
        }
    }
}
