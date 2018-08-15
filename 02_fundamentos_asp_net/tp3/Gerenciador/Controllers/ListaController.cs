using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador.Models;

namespace Gerenciador.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult Index()
        {
            ViewBag.Pessoas = Colection.Lista;
            return View();
        }
    }
}