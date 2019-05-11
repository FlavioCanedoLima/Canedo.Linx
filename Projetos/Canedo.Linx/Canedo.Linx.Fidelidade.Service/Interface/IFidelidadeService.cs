using Canedo.Linx.Fidelidade.Domain.Model;
using Refit;
using System.Threading.Tasks;

namespace Canedo.Linx.Fidelidade.ApiService.Interface
{
    public interface IFidelidadeService
    {
        [Post("/LinxServiceApi/FidelidadeService/ConsultaFidelizacao")]
        Task<HttpConsultaFidelizacao> PostConsultaFidelizacao([Body]ConsultaFidelizacaoBody consultaFidelizacao);
    }
}
