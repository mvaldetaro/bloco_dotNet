using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador.Models;

namespace Gerenciador.Controllers
{
    public class EdicaoController : Controller
    {
        // GET: Edicao
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

            //ViewBag.Pessoa = ObjPessoa;
            ViewBag.DataNascimento = String.Format("{0:d/M/yyyy}", ObjPessoa.DtAniversario).Replace("-", "/");

            return View(ObjPessoa);
        }

        [HttpPost]
        public ActionResult Submit(Pessoa pessoa)
        {
            foreach (var p in Colection.Lista)
            {
                if (p.Id == pessoa.Id)
                {
                    p.Nome = pessoa.Nome;
                    p.Sobrenome = pessoa.Sobrenome;
                    p.DtAniversario = pessoa.DtAniversario;
                }
            }

            return RedirectToAction("Index", "Lista");
        }
    }
}