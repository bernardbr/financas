using CalculaJuros.Api.Dominio.Servicos.Implementacoes;
using CalculaJuros.Api.Dominio.VOs;
using CalculaJuros.Unit.Tests.Stubs;
using Xunit;

namespace CalculaJuros.Unit.Tests.Dominio.Servicos.Implementacoes
{
    public class ServicoCalculoJurosCompostosTests
    {
        private readonly ServicoCalculoJurosCompostos _servico;

        public ServicoCalculoJurosCompostosTests()
        {
            _servico = new ServicoCalculoJurosCompostos();
        }

        [Theory]
        [MemberData(
            nameof(StubsJurosCompostos.JurosCompostosCorretosComResultados),
            MemberType = typeof(StubsJurosCompostos))]
        public void AoInformarJurosCompostosValidos_DeveApurarMontanteFinalComSucesso(JurosCompostos juros,
            double montanteEsperado)
        {
            var retorno = _servico.ApurarMontante(juros);
            Assert.Equal(montanteEsperado, retorno);
        }

        [Theory]
        [MemberData(
            nameof(StubsJurosCompostos.JurosCompostosMesesZerados),
            MemberType = typeof(StubsJurosCompostos))]
        public void AoInformarMesesIgualAZero_DeveRetornarOValorINicial(JurosCompostos juros)
        {
            var retorno = _servico.ApurarMontante(juros);
            var montanteEsperado = juros.ValorInicial;
            Assert.Equal(montanteEsperado, retorno);
        }
    }
}
