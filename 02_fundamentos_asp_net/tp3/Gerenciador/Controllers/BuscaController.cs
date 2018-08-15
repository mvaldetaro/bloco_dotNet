using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador.Models;

namespace Gerenciador.Controllers
{
    public class BuscaController : Controller
    {
        // GET: Busca
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Resultado(FormCollection collection)
        {
            ViewBag.Query = collection["query"];

            List<Pessoa> Pessoas = Colection.Lista;
            List<Pessoa> PessoasFilter = new List<Pessoa>();

            var Result = from ObjPessoa in Pessoas where ObjPessoa.Nome.Contains(ViewBag.Query) orderby ObjPessoa.Nome select ObjPessoa;

            foreach(Pessoa pessoa in Result)
            {
                PessoasFilter.Add(pessoa);
            }

            ViewBag.Pessoas = PessoasFilter;

            return View();
        }
    }
}