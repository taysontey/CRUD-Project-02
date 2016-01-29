using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class TimeMap : ClassMap<Time>
    {
        public TimeMap()
        {
            Table("TB_TIME");

            Id(t => t.IdTime, "IDTIME")
                .GeneratedBy.Identity();

            Map(t => t.Nome, "NOME")
                .Length(50)
                .Not.Nullable();

            Map(t => t.DataFundacao, "DATAFUNDACAO")
                .Not.Nullable();

            #region Relacionamentos

            HasMany(t => t.Jogadores)
                .KeyColumn("IDTIME")
                .Inverse();

            #endregion
        }
    }
}
