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
                TimeDal d = new TimeDal();

                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                d.SaveOrUpdate(t);

                return Json("Time " + t.Nome +  ", cadastrado com sucesso.");
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

                foreach(Time t in d.FindAll())
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

        public JsonResult Excluir(TimeModelExclusao model)
        {
            try
            {
                TimeDal d = new TimeDal();

                if (d.FindById(model.IdTime) != null)
                {
                    d.Delete(d.FindById(model.IdTime));
                }

                return Json("Time excluído.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}