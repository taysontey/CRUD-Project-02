using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class JogadorModelCadastro
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Posicao { get; set; }
        public int IdTime { get; set; }
    }

    public class JogadorModelEdicao
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Posicao { get; set; }
        public int IdTime { get; set; }
    }

    public class JogadorModelConsulta
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string DataNascimento { get; set; }
        public string Posicao { get; set; }
        public string Time { get; set; }
    }
}