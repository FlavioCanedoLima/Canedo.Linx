using Newtonsoft.Json;

namespace Canedo.Linx.Fidelidade.Domain.Model
{
    public class HttpConsultaFidelizacao
    {
        [JsonProperty("nsuCliente")]
        public string NsuCliente { get; set; }
        [JsonProperty("resultado")]
        public string Resultado { get; set; }
        [JsonProperty("saldoPontos")]
        public string SaldoPontos { get; set; }
        [JsonProperty("saldoEmPontos")]
        public string SaldoEmPontos { get; set; }
        [JsonProperty("saldoEmReais")]
        public string SaldoEmReais { get; set; }
        [JsonProperty("mensagemErro")]
        public string MensagemErro { get; set; }
    }
}