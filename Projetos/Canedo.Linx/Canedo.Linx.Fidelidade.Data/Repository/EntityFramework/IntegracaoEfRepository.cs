using Canedo.Linx.Fidelidade.Data.Context;
using Canedo.Linx.Fidelidade.Domain.Entity;
using Canedo.Linx.Fidelidade.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Canedo.Linx.Fidelidade.Data.Repository.EntityFramework
{
    public class IntegracaoEfRepository : IRepositoryCommand<Integracao>
    {
        readonly FidelidadeDbContext context_;

        public IntegracaoEfRepository(FidelidadeDbContext context)
        {
            context_ = context;
        }
        public bool Add(Integracao entity)
        {
            context_.Add(entity);
            return context_.SaveChanges() > 0;
        }

        public void Update(Integracao entity)
        {
            context_.Entry(entity).State = EntityState.Modified;
            context_.SaveChanges();
        }
    }
}
