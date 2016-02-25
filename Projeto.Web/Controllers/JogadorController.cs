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

        //Método para carregar o DropDown de times
        public JsonResult CarregarTimes()
        {
            try
            {
                TimeDal d = new TimeDal();

                var list = new List<TimeModelDropDown>();

                foreach (Time t in d.FindAll())
                {
                    var model = new TimeModelDropDown();

                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;

                    list.Add(model);
                }

                return Json(list);
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
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.Posicao = model.Posicao;
                j.DataNascimento = model.DataNascimento;
                j.Time.IdTime = model.IdTime;

                JogadorDal d = new JogadorDal();
                d.SaveOrUpdate(j);

                return Json("Jogador " + j.Nome + ", cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Editar(JogadorModelEdicao model)
        {
            try
            {
                JogadorDal d = new JogadorDal();
                Jogador j = d.FindById(model.IdJogador);

                if (j != null)
                {
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.Posicao = j.Posicao;
                    model.DataNascimento = j.DataNascimento;
                    model.IdTime = j.Time.IdTime;
                }

                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Edicao(JogadorModelEdicao model)
        {
            try
            {
                Jogador j = new Jogador();
                j.IdJogador = model.IdJogador;
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.Posicao = model.Posicao;
                j.DataNascimento = model.DataNascimento;

                j.Time = new Time();
                j.Time.IdTime = model.IdTime;

                JogadorDal d = new JogadorDal();
                d.SaveOrUpdate(j);

                return Json("Time editado com sucesso.");
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

                foreach (Jogador j in d.FindAll())
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

        public JsonResult Excluir(JogadorModelEdicao model)
        {
            try
            {
                JogadorDal d = new JogadorDal();
                Jogador j = d.FindById(model.IdJogador);

                if (j != null)
                {
                    d.Delete(j);
                    return Json("Jogador excluído.");
                }
                else
                {
                    return Json("Jogador não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}