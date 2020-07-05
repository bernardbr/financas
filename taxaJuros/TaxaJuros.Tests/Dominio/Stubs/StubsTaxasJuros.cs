namespace TaxaJuros.Tests.Dominio.Stubs
{
    using System.Collections.Generic;
    using TaxaJuros.Core.Dominio.VOs;

    public class StubsTaxasJuros
    {
        public static IEnumerable<object[]> TaxasJurosComRetorno()
        {
            yield return new object[] { new TaxaJuros(1), true };
            yield return new object[] { new TaxaJuros(2), false };
        }
    }
}