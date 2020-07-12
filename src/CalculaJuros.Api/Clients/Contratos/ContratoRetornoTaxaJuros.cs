using System.Runtime.Serialization;

namespace CalculaJuros.Api.Clients.Contratos
{
    [DataContract]
    public class ContratoRetornoTaxaJuros
    {
        [DataMember(EmitDefaultValue = false, Name = "taxaJuros")]
        public double TaxaJuros { get; set; }
    }
}
