using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EscalonamentoHorarios_Grupo3.Models;
using System.Threading;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    public class HomeController : Controller
    {
        public object JsonRequestBehavior { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ExampleDemo()
        {
            Thread.Sleep(1000);
            string status = "Task Completed Successfully";
            return Json(status, JsonRequestBehavior);
        }

        private ActionResult Json(string status, object allowGet)
        {
            throw new NotImplementedException();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Voluntario()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
