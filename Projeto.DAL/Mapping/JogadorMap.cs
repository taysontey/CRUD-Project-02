using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class JogadorMap : ClassMap<Jogador>
    {
        public JogadorMap()
        {
            Table("TB_JOGADOR");

            Id(j => j.IdJogador, "IDJOGADOR")
                .GeneratedBy.Identity();

            Map(j => j.Nome, "NOME")
                .Length(50)
                .Not.Nullable();

            Map(j => j.Apelido, "APELIDO")
                .Length(50)
                .Not.Nullable();

            Map(j => j.DataNascimento, "DATANASCIMENTO")
                .Not.Nullable();

            Map(j => j.Posicao, "POSICAO")
                .Length(25)
                .Not.Nullable();

            #region Relacionamentos

            References(j => j.Time)
                .Column("IDTIME")
                .Not.LazyLoad()
                .Not.Nullable();

            #endregion
        }
    }
}
