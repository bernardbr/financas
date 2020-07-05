namespace CalculaJuros.Tests.Stubs
{
    using System.Collections.Generic;
    using CalculaJuros.Core.Dominio.VOs;

    public class StubsCodigoFonte
    {
        public static IEnumerable<object[]> CodigosParaComparacao()
        {
            yield return new object[] { new CodigoFonte("http://www.meucodigo.com/source"), true };
            yield return new object[] { new CodigoFonte("http://www.teste.com.br/fontes"), false };
        }
    }
}