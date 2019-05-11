using Canedo.Linx.Fidelidade.Domain.Entity;
using Dapper.FluentMap.Dommel.Mapping;

namespace Canedo.Linx.Fidelidade.Data.Mapping
{
    public class FidelizacaoMap : DommelEntityMap<Fidelizacao>
    {
        public FidelizacaoMap()
        {
            ToTable("Fidelizacao");
            Map(x => x.Id).IsKey();
            Map(x => x.NsuCliente).ToColumn("NsuCliente");
            Map(x => x.Resultado).ToColumn("Resultado");
            Map(x => x.SaldoPontos).ToColumn("SaldoPontos");
            Map(x => x.SaldoEmPontos).ToColumn("SaldoEmPontos");
            Map(x => x.SaldoEmReais).ToColumn("SaldoEmReais");

        }
    }
}