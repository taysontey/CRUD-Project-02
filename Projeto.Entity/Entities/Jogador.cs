using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Jogador
    {
        public virtual int IdJogador { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Apelido { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Posicao { get; set; }
        public virtual int IdTime { get; set; }

        #region Relacionamentos

        public virtual Time Time { get; set; }

        #endregion
    }
}
