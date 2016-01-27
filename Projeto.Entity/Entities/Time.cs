using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Time
    {
        public virtual int IdTime { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataFundacao { get; set; }

        #region Relacionamentos

        public virtual ICollection<Jogador> Jogadores { get; set; }

        #endregion
    }
}
