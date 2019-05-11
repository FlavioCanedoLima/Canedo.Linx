using Canedo.Linx.Fidelidade.Data.Context;
using Canedo.Linx.Fidelidade.Domain.Entity;
using Canedo.Linx.Fidelidade.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Canedo.Linx.Fidelidade.Data.Repository.EntityFramework
{
    public class FidelizacaoEfRepository : IRepositoryCommand<Fidelizacao>
    {
        readonly FidelidadeDbContext context_;

        public FidelizacaoEfRepository(FidelidadeDbContext context)
        {
            context_ = context;
        }

        public bool Add(Fidelizacao entity)
        {
            context_.Add(entity);
            return context_.SaveChanges() > 0;
        }

        public void Update(Fidelizacao entity)
        {
            context_.Entry(entity).State = EntityState.Modified;
            context_.SaveChanges();
        }
    }
}
