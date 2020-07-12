using System.Collections.Generic;

namespace TaxaJuros.Unit.Tests.Dominio.Stubs
{
    public class StubsTaxasJuros
    {
        public static IEnumerable<object[]> TaxasJurosComRetorno()
        {
            yield return new object[] { new Api.Dominio.VOs.TaxaJuros(1), true };
            yield return new object[] { new Api.Dominio.VOs.TaxaJuros(2), false };
        }
    }
}
