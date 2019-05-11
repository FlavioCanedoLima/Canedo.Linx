using Canedo.Linx.Fidelidade.Domain.Entity;
using Dapper.FluentMap.Dommel.Mapping;

namespace Canedo.Linx.Fidelidade.Data.Mapping
{
    public class IntegracaoMap : DommelEntityMap<Integracao>
    {
        public IntegracaoMap()
        {
            ToTable("Integracao");
            Map(x => x.Id).IsKey();
            Map(x => x.ChaveIntegracao).ToColumn("ChaveIntegracao");
            Map(x => x.CodigoLoja).ToColumn("CodigoLoja");
        }
    }
}
