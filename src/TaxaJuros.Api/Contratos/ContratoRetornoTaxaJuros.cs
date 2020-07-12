using System.Runtime.Serialization;

namespace TaxaJuros.Api.Contratos
{
    [DataContract]
    public class ContratoRetornoTaxaJuros
    {
        /// <summary>
        /// A taxa de juros padrão.
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "taxaJuros")]
        public double TaxaJuros { get; set; }
    }
}
