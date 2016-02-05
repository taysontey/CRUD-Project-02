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
    public class TimeController : Controller
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

        public JsonResult Cadastrar(TimeModelCadastro model)
        {
            try
            {
                Time t = new Time();
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                TimeDal d = new TimeDal();
                d.SaveOrUpdate(t);

                return Json("Time " + t.Nome + ", cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Editar(TimeModelEdicao model)
        {
            try
            {
                TimeDal d = new TimeDal();
                Time t = d.FindById(model.IdTime);

                if (t != null)
                {
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao;
                }

                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Edicao(TimeModelEdicao model)
        {
            try
            {
                Time t = new Time();
                t.IdTime = model.IdTime;
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                TimeDal d = new TimeDal();
                d.SaveOrUpdate(t);

                return Json("Time editado com sucesso, atualizando...");
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
                var list = new List<TimeModelConsulta>();
                TimeDal d = new TimeDal();

                foreach (Time t in d.FindAll())
                {
                    var model = new TimeModelConsulta();

                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Excluir(TimeModelEdicao model)
        {
            try
            {
                TimeDal d = new TimeDal();
                Time t = d.FindById(model.IdTime);

                if (t != null)
                {
                    d.Delete(t);

                    return Json("Time excluído, atualizando...");
                }
                else
                {
                    return Json("Time não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}