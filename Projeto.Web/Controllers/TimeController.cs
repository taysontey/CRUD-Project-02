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

        [HttpPost]
        public JsonResult Cadastro(TimeModelCadastro model)
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
    }
}