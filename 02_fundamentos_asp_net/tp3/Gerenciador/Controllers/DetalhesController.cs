using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador.Models;

namespace Gerenciador.Controllers
{
    public class DetalhesController : Controller
    {
        // GET: Detalhes
        public ActionResult Index(String id)
        {
            ViewBag.Id = id;
            Pessoa ObjPessoa = new Pessoa();

            foreach (var p in Colection.Lista)
            {
                if(p.Id == id)
                {
                    ObjPessoa = p;
                }
            }

            ViewBag.DataNascimento = String.Format("{0:d/M/yyyy}", ObjPessoa.DtAniversario).Replace("-", "/");
            ViewBag.DiasRestantes = Calculator.DiasRestantesAniversario(ObjPessoa.DtAniversario);

            return View(ObjPessoa);
        }
    }
}