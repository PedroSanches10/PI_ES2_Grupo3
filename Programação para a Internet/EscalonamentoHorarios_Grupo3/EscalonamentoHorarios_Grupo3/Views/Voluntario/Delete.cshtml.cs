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
    public class DeleteModel : PageModel
    {
        private readonly EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext _context;

        public DeleteModel(EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Voluntario = await _context.Voluntario.FirstOrDefaultAsync(m => m.VoluntarioID == id);

            if (Voluntario == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Voluntario = await _context.Voluntario.FindAsync(id);

            if (Voluntario != null)
            {
                _context.Voluntario.Remove(Voluntario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
