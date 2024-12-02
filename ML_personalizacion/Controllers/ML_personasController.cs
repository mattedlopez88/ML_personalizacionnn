using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ML_DB;
using ML_personalizacion.Models;

namespace ML_personalizacion.Controllers
{
    public class ML_personasController : Controller
    {
        private readonly Context _context;

        public ML_personasController(Context context)
        {
            _context = context;
        }

        // GET: ML_personas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ML_personas.ToListAsync());
        }

        // GET: ML_personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mL_personas = await _context.ML_personas
                .FirstOrDefaultAsync(m => m.ML_id == id);
            if (mL_personas == null)
            {
                return NotFound();
            }

            return View(mL_personas);
        }

        // GET: ML_personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ML_personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ML_id,ML_nombre,ML_apellido,ML_email,ML_telefono")] ML_personas mL_personas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mL_personas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mL_personas);
        }

        // GET: ML_personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mL_personas = await _context.ML_personas.FindAsync(id);
            if (mL_personas == null)
            {
                return NotFound();
            }
            return View(mL_personas);
        }

        // POST: ML_personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ML_id,ML_nombre,ML_apellido,ML_email,ML_telefono")] ML_personas mL_personas)
        {
            if (id != mL_personas.ML_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mL_personas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ML_personasExists(mL_personas.ML_id))
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
            return View(mL_personas);
        }

        // GET: ML_personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mL_personas = await _context.ML_personas
                .FirstOrDefaultAsync(m => m.ML_id == id);
            if (mL_personas == null)
            {
                return NotFound();
            }

            return View(mL_personas);
        }

        // POST: ML_personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mL_personas = await _context.ML_personas.FindAsync(id);
            if (mL_personas != null)
            {
                _context.ML_personas.Remove(mL_personas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ML_personasExists(int id)
        {
            return _context.ML_personas.Any(e => e.ML_id == id);
        }
    }
}
