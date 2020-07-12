using System.Runtime.Serialization;

namespace CalculaJuros.Api.Contratos
{
    [DataContract]
    public class ContratoRetornoShowCode
    {
        /// <summary>
        /// A URL onde estão hospedados os fontes
        /// </summary>
        [DataMember(EmitDefaultValue = false, Name = "urlProjeto")]
        public string UrlProjeto { get; set; }
    }
}
