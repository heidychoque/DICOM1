using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listaAgregados1()
        {

            return View();
        }
        public ActionResult listaAgregados()
        {
            PersonaService p = new PersonaService();
            var model = p.obtenerPersonas();
            return View(model);
        }
        public ActionResult CheckMessage()
        {
            ParserService p = new ParserService();
            //p.reader2();
            var model = p.reader2();
            return View(model);

        }

    }
}