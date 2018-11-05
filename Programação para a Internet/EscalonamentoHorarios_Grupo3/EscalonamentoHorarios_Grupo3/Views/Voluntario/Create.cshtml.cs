using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscalonamentoHorarios_Grupo3.Data;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext _context;

        public CreateModel(EscalonamentoHorarios_Grupo3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Voluntario.Add(Voluntario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}