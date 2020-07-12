using System.Runtime.Serialization;

namespace CalculaJuros.Api.Contratos
{
    [DataContract]
    public class ContratoRetornoMontanteJuros
    {
        /// <summary>
        /// O valor final somado aos juros calculados
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "montante")]
        public double Montante { get; set; }
    }
}
