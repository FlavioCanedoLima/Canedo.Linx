using Canedo.Linx.Fidelidade.Domain.Abstract;

namespace Canedo.Linx.Fidelidade.Domain.Interface.Repository
{
    public interface IRepositoryCommand<TEntity> where TEntity : EntityBase
    {
        bool Add(TEntity entity);
        void Update(TEntity entity);
    }
}
