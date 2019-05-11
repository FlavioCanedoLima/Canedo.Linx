using Canedo.Linx.Fidelidade.Data.Mapping;
using Canedo.Linx.Fidelidade.Domain.Entity;
using Canedo.Linx.Fidelidade.Domain.Interface.Repository;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Canedo.Linx.Fidelidade.Data.Repository.Dapper
{
    public class IntegracaoDapperRepository : IRepositoryQuery<Integracao>
    {
        readonly IConfiguration configuration_;
        readonly SqlConnection sqlConnection_;

        public IntegracaoDapperRepository(IConfiguration configuration)
        {
            configuration_ = configuration;
            

            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new IntegracaoMap());
                    c.AddMap(new FidelizacaoMap());
                    c.ForDommel();
                });
            }

            sqlConnection_ = new SqlConnection(configuration_.GetSection("ConnectionStrings:Fidelidade").Value);
        }

        public IEnumerable<Integracao> GetAll()
        {
            return sqlConnection_.GetAll<Integracao>();
        }

        public Integracao GetById(Guid id)
        {
            return sqlConnection_.Get<Integracao>(id);
        }
    }
}
