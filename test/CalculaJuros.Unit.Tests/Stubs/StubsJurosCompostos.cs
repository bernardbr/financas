using CalculaJuros.Api.Dominio.VOs;
using System.Collections.Generic;

namespace CalculaJuros.Unit.Tests.Stubs
{
    public class StubsJurosCompostos
    {
        private static readonly JurosCompostos _jurosCinco;
        private static readonly JurosCompostos _jurosDois;
        private static readonly JurosCompostos _jurosQuatro;
        private static readonly JurosCompostos _jurosSeis;
        private static readonly JurosCompostos _jurosTres;
        private static readonly JurosCompostos _jurosUm;

        static StubsJurosCompostos()
        {
            _jurosCinco = new JurosCompostos(-2, -0.2, 2);
            _jurosDois = new JurosCompostos(2, 0.2, 2);
            _jurosQuatro = new JurosCompostos(2, -0.2, 2);
            _jurosSeis = new JurosCompostos(100, 0.01, 5);
            _jurosTres = new JurosCompostos(-2, 0.2, 2);
            _jurosUm = new JurosCompostos(0, 0, 0);
        }

        public static IEnumerable<object[]> JurosCompostosCorretos()
        {
            yield return new object[] { _jurosUm };
            yield return new object[] { _jurosDois };
            yield return new object[] { _jurosTres };
            yield return new object[] { _jurosQuatro };
            yield return new object[] { _jurosCinco };
            yield return new object[] { _jurosSeis };
        }

        public static IEnumerable<object[]> JurosCompostosCorretosComResultados()
        {
            yield return new object[] { _jurosUm, 0 };
            yield return new object[] { _jurosDois, 2.88 };
            yield return new object[] { _jurosTres, -2.88 };
            yield return new object[] { _jurosQuatro, 1.28 };
            yield return new object[] { _jurosCinco, -1.28 };
            yield return new object[] { _jurosSeis, 105.10 };
        }

        public static IEnumerable<object[]> JurosCompostosMesesZerados()
        {
            yield return new object[] { new JurosCompostos(1, 2, 0) };
            yield return new object[] { new JurosCompostos(0, 2, 0) };
            yield return new object[] { new JurosCompostos(1, 0, 0) };
            yield return new object[] { new JurosCompostos(1, 2, 0) };
        }

        public static IEnumerable<object[]> JurosCompostosParaComparacao()
        {
            yield return new object[] { new JurosCompostos(1, 2, 3), true };
            yield return new object[] { new JurosCompostos(0, 2, 3), false };
            yield return new object[] { new JurosCompostos(1, 0, 3), false };
            yield return new object[] { new JurosCompostos(1, 2, 0), false };
        }
    }
}
