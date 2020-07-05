namespace CalculaJuros.Api.Clients.Contratos
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ContratoRetornoTaxaJuros
    {
        [DataMember(EmitDefaultValue = false, Name = "taxaJuros")]        
        public double taxaJuros { get; set; }
    }
}