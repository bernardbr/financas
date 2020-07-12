using CalculaJuros.Api.Dominio.VOs;
using System.Collections.Generic;

namespace CalculaJuros.Unit.Tests.Stubs
{
    public class StubsCodigoFonte
    {
        public static IEnumerable<object[]> CodigosParaComparacao()
        {
            yield return new object[] { new CodigoFonte("http://www.meucodigo.com/source"), true };
            yield return new object[] { new CodigoFonte("http://www.teste.com.br/fontes"), false };
        }
    }
}
