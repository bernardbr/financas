namespace TaxaJuros.Api.Contratos
{
    using System.Runtime.Serialization;

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