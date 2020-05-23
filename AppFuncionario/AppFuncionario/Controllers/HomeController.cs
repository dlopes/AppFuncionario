using AppFuncionario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFuncionario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repositorio = new PessoaRepository();
            var pessoas = repositorio.GetPessoas();
     
            return View(pessoas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}