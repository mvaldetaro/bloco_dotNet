using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador.Models;

namespace Gerenciador.Controllers
{
    public class DelecaoController : Controller
    {
        // GET: Delecao
        public ActionResult Index(String id)
        {
            Pessoa ObjPessoa = new Pessoa();
            foreach (var p in Colection.Lista)
            {
                if (p.Id == id)
                {
                    ObjPessoa = p;
                }
            }

            //ViewBag.Id = id;
            //ViewBag.NomeCompleto = $"{ObjPessoa.Nome} {ObjPessoa.Sobrenome}";

            return View(ObjPessoa);
        }

        // GET: Excluir
        public ActionResult Excluir(String id)
        {
            Pessoa ObjPessoa = new Pessoa();

            foreach (var p in Colection.Lista)
            {
                if (p.Id == id)
                {
                    ObjPessoa = p;
                }
            }

            Colection.Lista.Remove(ObjPessoa);

            return RedirectToAction("Index", "Lista");
        }
    }
}