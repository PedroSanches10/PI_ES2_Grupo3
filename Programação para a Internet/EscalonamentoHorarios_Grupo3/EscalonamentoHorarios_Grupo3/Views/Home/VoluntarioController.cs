using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EscalonamentoHorarios_Grupo3.Views.Home
{
    public class VoluntarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}