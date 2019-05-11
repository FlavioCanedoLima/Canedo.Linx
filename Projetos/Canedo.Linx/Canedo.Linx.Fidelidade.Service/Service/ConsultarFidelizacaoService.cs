using Canedo.Linx.Fidelidade.ApiService.Interface;
using Canedo.Linx.Fidelidade.Domain.Model;
using Microsoft.Extensions.Configuration;
using Refit;

namespace Canedo.Linx.Fidelidade.ApiService.Service
{
    public class ConsultarFidelizacaoService
    {
        readonly IConfiguration configuration_;

        public ConsultarFidelizacaoService(IConfiguration configuration)
        {
            configuration_ = configuration;
        }

        public HttpConsultaFidelizacao GetConsultaFidelizacao(ConsultaFidelizacaoBody consultarFidelizacao)
        {
            try
            {
                return
                RestService
                .For<IFidelidadeService>(configuration_.GetSection("Linx:ApiBaseUrl").Value)
                .PostConsultaFidelizacao(consultarFidelizacao)
                .Result;
            }
            catch (System.Exception)
            {
                return default;
            }
            
        }
    }
}
