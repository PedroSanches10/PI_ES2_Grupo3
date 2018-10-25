using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Controllers

{
    public class Enfermeiro: Controller
    {
        public IActionResult Enfermeiro()
        {
            return View();
        }
    }
}
