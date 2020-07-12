using CalculaJuros.Api.Dominio.VOs;

namespace CalculaJuros.Api.Dominio.Servicos.Interfaces
{
    public interface IServicoCalculoJurosCompostos
    {
        double ApurarMontante(JurosCompostos juros);
    }
}
