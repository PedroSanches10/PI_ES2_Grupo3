using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EscalonamentoHorarios_Grupo3.Data;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext _context;

        public IndexModel(EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Voluntario> Voluntario { get;set; }

        public async Task OnGetAsync()
        {
            Voluntario = await _context.Voluntario.ToListAsync();
        }
    }
}
