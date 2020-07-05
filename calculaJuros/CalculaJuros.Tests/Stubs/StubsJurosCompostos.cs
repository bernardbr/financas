namespace CalculaJuros.Tests.Stubs
{
    using System.Collections.Generic;
    using CalculaJuros.Core.Dominio.VOs;

    public class StubsJurosCompostos
    {
        private static readonly JurosCompostos JurosUm = new JurosCompostos(0, 0, 0);
        private static readonly JurosCompostos JurosDois = new JurosCompostos(2, 0.2, 2);
        private static readonly JurosCompostos JurosTres = new JurosCompostos(-2, 0.2, 2);
        private static readonly JurosCompostos JurosQuatro = new JurosCompostos(2, -0.2, 2);
        private static readonly JurosCompostos JurosCinco = new JurosCompostos(-2, -0.2, 2);
        private static readonly JurosCompostos JurosSeis = new JurosCompostos(100, 0.01, 5);

        public static IEnumerable<object[]> JurosCompostosCorretos()
        {
            yield return new object[] { JurosUm };
            yield return new object[] { JurosDois };
            yield return new object[] { JurosTres };
            yield return new object[] { JurosQuatro };
            yield return new object[] { JurosCinco };
            yield return new object[] { JurosSeis };
        }

        public static IEnumerable<object[]> JurosCompostosCorretosComResultados()        
        {
            yield return new object[] { JurosUm, 0 };
            yield return new object[] { JurosDois, 2.88 };
            yield return new object[] { JurosTres, -2.88 };
            yield return new object[] { JurosQuatro, 1.28 };
            yield return new object[] { JurosCinco, -1.28 };
            yield return new object[] { JurosSeis, 105.10 };
        }

        public static IEnumerable<object[]> JurosCompostosParaComparacao()
        {
            yield return new object[] { new JurosCompostos(1, 2, 3), true };
            yield return new object[] { new JurosCompostos(0, 2, 3), false };
            yield return new object[] { new JurosCompostos(1, 0, 3), false };
            yield return new object[] { new JurosCompostos(1, 2, 0), false };          
        }

        public static IEnumerable<object[]> JurosCompostosMesesZerados()
        {
            yield return new object[] { new JurosCompostos(1, 2, 0) };
            yield return new object[] { new JurosCompostos(0, 2, 0) };
            yield return new object[] { new JurosCompostos(1, 0, 0) };
            yield return new object[] { new JurosCompostos(1, 2, 0) };
        }
    }
}