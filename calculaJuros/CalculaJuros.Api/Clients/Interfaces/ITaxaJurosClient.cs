namespace CalculaJuros.Api.Clients.Interfaces
{
    using System.Threading.Tasks;
    
    public interface ITaxaJurosClient
    {
        Task<double> ObterTaxaJuros();
    }
}