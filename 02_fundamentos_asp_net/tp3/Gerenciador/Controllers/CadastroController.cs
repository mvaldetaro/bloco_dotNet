using Gerenciador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerenciador.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Pessoa pessoa)
        {
            Colection.Lista.Add(pessoa);
            return RedirectToAction("Index","Home");
        }
    }
}