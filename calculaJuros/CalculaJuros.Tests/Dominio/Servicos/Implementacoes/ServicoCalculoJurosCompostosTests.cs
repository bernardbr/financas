namespace CalculaJuros.Tests.Dominio.Servicos.Implementacoes
{
    using CalculaJuros.Core.Dominio.Servicos.Implementacoes;
    using CalculaJuros.Core.Dominio.VOs;
    using CalculaJuros.Tests.Stubs;
    using Xunit;

    public class ServicoCalculoJurosCompostosTests
    {
        private ServicoCalculoJurosCompostos _servico;

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