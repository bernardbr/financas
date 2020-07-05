namespace CalculaJuros.Api.Contratos
{
    using System.Runtime.Serialization;

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