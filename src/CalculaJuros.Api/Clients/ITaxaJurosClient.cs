using System.Threading.Tasks;

namespace CalculaJuros.Api.Clients
{
    public interface ITaxaJurosClient
    {
        Task<double> ObterTaxaJuros();
    }
}
