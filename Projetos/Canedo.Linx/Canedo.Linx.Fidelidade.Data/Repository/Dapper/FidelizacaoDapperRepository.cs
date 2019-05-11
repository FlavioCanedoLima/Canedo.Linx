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
    public class FidelizacaoDapperRepository : IRepositoryQuery<Fidelizacao>
    {
        readonly IConfiguration configuration_;
        readonly SqlConnection sqlConnection_;

        public FidelizacaoDapperRepository(IConfiguration configuration)
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
        public IEnumerable<Fidelizacao> GetAll()
        {
            return sqlConnection_.GetAll<Fidelizacao>();
        }

        public Fidelizacao GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }
    }
}
