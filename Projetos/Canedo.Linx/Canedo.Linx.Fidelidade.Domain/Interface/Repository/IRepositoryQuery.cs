using Canedo.Linx.Fidelidade.Domain.Abstract;
using System;
using System.Collections.Generic;

namespace Canedo.Linx.Fidelidade.Domain.Interface.Repository
{
    public interface IRepositoryQuery<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
