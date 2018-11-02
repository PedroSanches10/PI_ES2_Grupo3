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
    public class UnidadesServicoController : Controller
    {
        private readonly EscalonamentoHorarios_Grupo3DbContext _context;

        public UnidadesServicoController(EscalonamentoHorarios_Grupo3DbContext context)
        {
            _context = context;
        }

        // GET: UnidadesServico
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadesServico.ToListAsync());
        }

        // GET: UnidadesServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesServico = await _context.UnidadesServico
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidadesServico == null)
            {
                return NotFound();
            }

            return View(unidadesServico);
        }

        // GET: UnidadesServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadesServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] UnidadesServico unidadesServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadesServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesServico);
        }

        // GET: UnidadesServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesServico = await _context.UnidadesServico.FindAsync(id);
            if (unidadesServico == null)
            {
                return NotFound();
            }
            return View(unidadesServico);
        }

        // POST: UnidadesServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] UnidadesServico unidadesServico)
        {
            if (id != unidadesServico.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadesServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesServicoExists(unidadesServico.ID))
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
            return View(unidadesServico);
        }

        // GET: UnidadesServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesServico = await _context.UnidadesServico
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidadesServico == null)
            {
                return NotFound();
            }

            return View(unidadesServico);
        }

        // POST: UnidadesServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadesServico = await _context.UnidadesServico.FindAsync(id);
            _context.UnidadesServico.Remove(unidadesServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesServicoExists(int id)
        {
            return _context.UnidadesServico.Any(e => e.ID == id);
        }
    }
}
