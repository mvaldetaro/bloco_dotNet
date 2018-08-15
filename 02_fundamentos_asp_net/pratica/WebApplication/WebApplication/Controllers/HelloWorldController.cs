using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index(string firstName, string lastName)
        {
            ViewBag.Message = $"Hello, {firstName} {lastName}!";

            return View();
        }
    }
}