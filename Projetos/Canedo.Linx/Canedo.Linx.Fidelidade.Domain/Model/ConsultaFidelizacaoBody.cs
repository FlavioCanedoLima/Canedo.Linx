using Newtonsoft.Json;

namespace Canedo.Linx.Fidelidade.Domain.Model
{
    public class ConsultaFidelizacaoBody
    {
        [JsonProperty("chaveIntegracao")]
        public string ChaveIntegracao { get; set; }
        [JsonProperty("codigoLoja")]
        public string CodigoLoja { get; set; }
        [JsonProperty("numeroCartao")]
        public string NumeroCartao { get; set; }
        [JsonProperty("nsuCliente")]
        public string NsuCliente { get; set; }
        [JsonProperty("codigoSeguranca")]
        public string CodigoSeguranca { get; set; }
    }
}