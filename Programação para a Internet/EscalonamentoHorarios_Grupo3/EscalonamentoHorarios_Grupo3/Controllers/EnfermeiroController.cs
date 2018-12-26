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
        private const int PAGE_SIZE = 5;
        private readonly EscalonamentoHorarios_Grupo3DbContext _context;

        public EnfermeiroController(EscalonamentoHorarios_Grupo3DbContext context)
        {
            _context = context;
        }

        // GET: Enfermeiro
        public async Task<IActionResult> Index(EnfermeirosListViewModel model = null, int page = 1)
        {
            string category = null;

            if (model != null)
            {
                category = model.CurrentNome;
                page = 1;
            }

            var enfermeiros = _context.Enfermeiros
                .Where(p => category == null || p.Nome.Contains(category));

            int numEnfermeiros = await enfermeiros.CountAsync();

            if (page > (numEnfermeiros / PAGE_SIZE) + 1)
            {
                page = 1;
            }

            var enfermeirosList = await enfermeiros
                    .OrderBy(p => p.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();

            return View(
                new EnfermeirosListViewModel
                {
                    Enfermeiros = enfermeirosList,
                    Paginacao = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        TotalItems = numEnfermeiros
                    },
                    CurrentNome = category
                }
            );
        }

        // GET: Enfermeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            }

            var product = await _context.Enfermeiros
                .FirstOrDefaultAsync(p => p.EnfermeiroId == id);

            if (product == null)
            {
                return NotFound(); // todo: replace by a view showing a more insightfull message
            }

            return View(product);
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
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Price,Category")] Enfermeiro enfermeiro)
        {
            if (!ModelState.IsValid)
            {
                return View(enfermeiro);
            }

            _context.Add(enfermeiro);
            await _context.SaveChangesAsync();

            // todo: inform user of the operation success
            return RedirectToAction(nameof(Index));
        }

        // GET: Enfermeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Enfermeiros.FindAsync(id);
            if (product == null)
            {
                // todo: inform user ...
                return NotFound();
            }
            return View(product);
        }

        // POST: Enfermeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Price,Category")] Enfermeiro enfermeiro)
        {
            if (id != enfermeiro.EnfermeiroId)
            {
                // todo: inform user ...
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(enfermeiro);
            }

            try
            {
                _context.Update(enfermeiro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(enfermeiro.EnfermeiroId))
                {
                    // todo: show an error message, decide what to do ...
                    return NotFound();
                }
                else
                {
                    // todo: show a message? try again?
                    throw;
                }
            }

            // todo: inform user of the operation success
            return RedirectToAction(nameof(Index));
        }

        // GET: Enfermeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Enfermeiros
                .FirstOrDefaultAsync(p => p.EnfermeiroId == id);

            if (product == null)
            {
                // show appropriate message
                return NotFound();
            }

            return View(product);
        }

        // POST: Enfermeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // todo: add additional verification checking the product id
            var product = await _context.Enfermeiros.FindAsync(id);
            if (product != null)
            {
                _context.Enfermeiros.Remove(product);
                await _context.SaveChangesAsync();
            }

            // todo: inform user of the operation success
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Enfermeiros.Any(p => p.EnfermeiroId == id);
        }
    }
}

