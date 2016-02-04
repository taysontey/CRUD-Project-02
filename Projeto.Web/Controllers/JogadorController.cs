using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;
using Projeto.Web.Models;

namespace Projeto.Web.Controllers
{
    public class JogadorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult CarregarTimes()
        {
            try
            {
                TimeDal d = new TimeDal();

                var lista = new List<TimeModelDropDown>();

                foreach (Time t in d.FindAll())
                {
                    var model = new TimeModelDropDown();

                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;

                    lista.Add(model);
                }

                return Json(lista);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Cadastrar(JogadorModelCadastro model)
        {
            try
            {
                Jogador j = new Jogador();
                JogadorDal d = new JogadorDal();

                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.Posicao = model.Posicao;
                j.DataNascimento = model.DataNascimento;
                j.Time = new Time();
                j.Time.IdTime = model.IdTime;

                d.SaveOrUpdate(j);

                return Json("Jogador " + j.Nome + ", cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Consultar()
        {
            try
            {
                JogadorDal d = new JogadorDal();
                var list = new List<JogadorModelConsulta>();

                foreach(Jogador j in d.FindAll())
                {
                    var model = new JogadorModelConsulta();

                    model.IdJogador = j.IdJogador;
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.Posicao = j.Posicao;
                    model.DataNascimento = j.DataNascimento.ToString("dd/MM/yyyy");
                    model.Time = j.Time.Nome;

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}