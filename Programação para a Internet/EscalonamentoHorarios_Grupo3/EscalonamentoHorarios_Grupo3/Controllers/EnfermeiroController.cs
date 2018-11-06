using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    public class EnfermeiroController : Controller
    {
        private readonly EscalonamentoHorarios_Grupo3DbContext _context;

        public EnfermeiroController(EscalonamentoHorarios_Grupo3DbContext context)
        {
            _context = context;
        }

        // GET: Enfermeiroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enfermeiro.ToListAsync());
        }

        // GET: Enfermeiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // GET: Enfermeiroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermeiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre")] Enfermeiro enfermeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermeiro);
        }

        // GET: Enfermeiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiro.FindAsync(id);
            if (enfermeiro == null)
            {
                return NotFound();
            }
            return View(enfermeiro);
        }

        // POST: Enfermeiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CellPhone,Department,Email,Street,Genre")] Enfermeiro enfermeiro)
        {
            if (id != enfermeiro.ID)
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
                    if (!EnfermeiroExists(enfermeiro.ID))
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

        // GET: Enfermeiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // POST: Enfermeiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermeiro = await _context.Enfermeiro.FindAsync(id);
            _context.Enfermeiro.Remove(enfermeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeiroExists(int id)
        {
            return _context.Enfermeiro.Any(e => e.ID == id);
        }
    }
}
