namespace CalculaJuros.Core.Dominio.Servicos.Interfaces
{
    using CalculaJuros.Core.Dominio.VOs;

    public interface IServicoCalculoJurosCompostos
    {
        double ApurarMontante(JurosCompostos juros);         
    }
}