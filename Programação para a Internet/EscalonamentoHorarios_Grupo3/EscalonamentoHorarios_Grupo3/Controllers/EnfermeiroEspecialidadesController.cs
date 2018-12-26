﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Controllers
{
    public class EnfermeiroEspecialidadesController : Controller
    {
        private const int PAGE_SIZE = 12;
        private readonly EscalonamentoHorarios_Grupo3DbContext _context;

        public EnfermeiroEspecialidadesController(EscalonamentoHorarios_Grupo3DbContext context)
        {
            _context = context;
        }

        // GET: EnfermeiroEspecialidades
        public async Task<IActionResult> Index(HistoricoEspecialidadesEnfermeiroViewModel model = null, int page = 1)
        {
            string nome = null;

            if (model != null && model.CurrentNome != null)
            {
                nome = model.CurrentNome;
                page = 1;
            }

            var historico = _context.EnfermeirosEspecialidades
                .Where(e => nome == null || e.Enfermeiro.Nome.Contains(nome));

            int numHistorico = await historico.CountAsync();

            if (page > (numHistorico / PAGE_SIZE) + 1)
            {
                page = 1;
            }

            var listahistorico = await historico
                .Include(e => e.EspecialidadeEnfermeiro)
                .Include(e => e.Enfermeiro)
                .OrderBy(e => e.Data_Registo)
                .Skip(PAGE_SIZE * (page - 1))
                .Take(PAGE_SIZE)
                .ToListAsync();

            return View(
                new HistoricoEspecialidadesEnfermeiroViewModel
                {
                    EnfermeirosEspecialidades = historico,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        TotalItems = numHistorico
                    },
                    CurrentNome = nome
                }
            );

        }

        // GET: EnfermeiroEspecialidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiroEspecialidade = await _context.EnfermeirosEspecialidades
                .Include(e => e.Enfermeiro)
                .Include(e => e.EspecialidadeEnfermeiro)
                .FirstOrDefaultAsync(m => m.EnfermeiroId == id);
            if (enfermeiroEspecialidade == null)
            {
                return NotFound();
            }

            return View(enfermeiroEspecialidade);
        }

        // GET: EnfermeiroEspecialidades/Create
        public IActionResult Create()
        {
            ViewData["EnfermeiroId"] = new SelectList(_context.Enfermeiros, "EnfermeiroId", "Nome");
            ViewData["EspecialidadeEnfermeiroId"] = new SelectList(_context.Set<EspecialidadeEnfermeiro>(), "EspecialidadeEnfermeiroId", "Especialidade");
            return View();
        }

        // POST: EnfermeiroEspecialidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecialidadeEnfermeiroId,EnfermeiroId,Data_Registo")] EnfermeiroEspecialidade enfermeiroEspecialidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeiroEspecialidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnfermeiroId"] = new SelectList(_context.Enfermeiros, "EnfermeiroId", "Nome", enfermeiroEspecialidade.EnfermeiroId);
            ViewData["EspecialidadeEnfermeiroId"] = new SelectList(_context.Set<EspecialidadeEnfermeiro>(), "EspecialidadeEnfermeiroId", "Especialidade", enfermeiroEspecialidade.EspecialidadeEnfermeiroId);
            return View(enfermeiroEspecialidade);
        }

        // GET: EnfermeiroEspecialidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiroEspecialidade = await _context.EnfermeirosEspecialidades.FindAsync(id);
            if (enfermeiroEspecialidade == null)
            {
                return NotFound();
            }
            ViewData["EnfermeiroId"] = new SelectList(_context.Enfermeiros, "EnfermeiroId", "Nome", enfermeiroEspecialidade.EnfermeiroId);
            ViewData["EspecialidadeEnfermeiroId"] = new SelectList(_context.Set<EspecialidadeEnfermeiro>(), "EspecialidadeEnfermeiroId", "Especialidade", enfermeiroEspecialidade.EspecialidadeEnfermeiroId);
            return View(enfermeiroEspecialidade);
        }

        // POST: EnfermeiroEspecialidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecialidadeEnfermeiroId,EnfermeiroId,Data_Registo")] EnfermeiroEspecialidade enfermeiroEspecialidade)
        {
            if (id != enfermeiroEspecialidade.EnfermeiroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermeiroEspecialidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeiroEspecialidadeExists(enfermeiroEspecialidade.EnfermeiroId))
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
            ViewData["EnfermeiroId"] = new SelectList(_context.Enfermeiros, "EnfermeiroId", "Nome", enfermeiroEspecialidade.EnfermeiroId);
            ViewData["EspecialidadeEnfermeiroId"] = new SelectList(_context.Set<EspecialidadeEnfermeiro>(), "EspecialidadeEnfermeiroId", "Especialidade", enfermeiroEspecialidade.EspecialidadeEnfermeiroId);
            return View(enfermeiroEspecialidade);
        }

        // GET: EnfermeiroEspecialidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeiroEspecialidade = await _context.EnfermeirosEspecialidades
                .Include(e => e.Enfermeiro)
                .Include(e => e.EspecialidadeEnfermeiro)
                .FirstOrDefaultAsync(m => m.EnfermeiroId == id);
            if (enfermeiroEspecialidade == null)
            {
                return NotFound();
            }

            return View(enfermeiroEspecialidade);
        }

        // POST: EnfermeiroEspecialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermeiroEspecialidade = await _context.EnfermeirosEspecialidades.FindAsync(id);
            _context.EnfermeirosEspecialidades.Remove(enfermeiroEspecialidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeiroEspecialidadeExists(int id)
        {
            return _context.EnfermeirosEspecialidades.Any(e => e.EnfermeiroId == id);
        }
    }
}