namespace CalculaJuros.Core.Dominio.Servicos.Implementacoes
{
    using System;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using CalculaJuros.Core.Dominio.VOs;
    
    public class ServicoCalculoJurosCompostos : IServicoCalculoJurosCompostos
    {
        private double TruncarValor(double valor, int precisao)
        {
            var fatorConversao = Math.Pow(10, precisao);
            var retorno = Math.Truncate(valor * fatorConversao) / fatorConversao;
            return retorno;
        }

        public double ApurarMontante(JurosCompostos juros)
        {            
            if (juros.Meses == 0)
                return juros.ValorInicial;
            
            var aliquota = 1 + juros.TaxaJuros;
            var aliquotaFinal = Math.Pow(aliquota, juros.Meses);
            var montante = juros.ValorInicial * aliquotaFinal;
            montante = TruncarValor(montante, 2);
            return montante;
        } 
    }
}