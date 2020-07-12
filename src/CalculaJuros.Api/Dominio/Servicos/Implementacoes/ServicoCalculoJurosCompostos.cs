using CalculaJuros.Api.Dominio.Servicos.Interfaces;
using CalculaJuros.Api.Dominio.VOs;
using System;

namespace CalculaJuros.Api.Dominio.Servicos.Implementacoes
{
    public class ServicoCalculoJurosCompostos : IServicoCalculoJurosCompostos
    {
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

        private double TruncarValor(double valor, int precisao)
        {
            var fatorConversao = Math.Pow(10, precisao);
            var retorno = Math.Truncate(valor * fatorConversao) / fatorConversao;
            return retorno;
        }
    }
}
