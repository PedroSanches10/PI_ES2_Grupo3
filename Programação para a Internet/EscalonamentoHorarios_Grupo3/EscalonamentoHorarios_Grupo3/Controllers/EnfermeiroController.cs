using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscalonamentoHorarios_Grupo3.Models;
using Microsoft.AspNetCore.Authorization;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    [Authorize(Policy = "OnlyAdminAccess")]
    public class EnfermeiroController : Controller
    {
        private readonly EscalonamentoHorarios_Grupo3DbContext _context;

        public EnfermeiroController(EscalonamentoHorarios_Grupo3DbContext context)
        {
            _context = context;
        }

        // GET: Enfermeiro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enfermeiros.ToListAsync());
        }

        // GET: Enfermeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros
                .FirstOrDefaultAsync(m => m.EnfermeiroID == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // GET: Enfermeiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermeiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnfermeiroID,Nome,Password,ConfirmPassword,Morada,UnidadeServico,CodPostal,Email,Telemovel,DataNascimento,NIF")] Enfermeiro enfermeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermeiro);
        }

        // GET: Enfermeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros.FindAsync(id);
            if (enfermeiro == null)
            {
                return NotFound();
            }
            return View(enfermeiro);
        }

        // POST: Enfermeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnfermeiroID,Nome,Password,ConfirmPassword,Morada,UnidadeServico,CodPostal,Email,Telemovel,DataNascimento,NIF")] Enfermeiro enfermeiro)
        {
            if (id != enfermeiro.EnfermeiroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeiroExists(enfermeiro.EnfermeiroID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enfermeiro);
        }

        // GET: Enfermeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros
                .FirstOrDefaultAsync(m => m.EnfermeiroID == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // POST: Enfermeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermeiro = await _context.Enfermeiros.FindAsync(id);
            _context.Enfermeiros.Remove(enfermeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeiroExists(int id)
        {
            return _context.Enfermeiros.Any(e => e.EnfermeiroID == id);
        }
    }
}
