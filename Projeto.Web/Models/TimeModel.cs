using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class TimeModelCadastro
    {
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
    }

    public class TimeModelEdicao
    {
        public int IdTime { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
    }

    public class TimeModelConsulta
    {
        public int IdTime { get; set; }
        public string Nome { get; set; }
        public string DataFundacao { get; set; }
    }

    public class TimeModelDropDown
    {
        public int IdTime { get; set; }
        public string Nome { get; set; }
    }
}