using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibreriaWeb.Data;
using LibreriaWeb.Models;

namespace LibreriaWeb.Controllers
{
    public class OrdenController : Controller
    {
        private readonly LibreriaDbContext _context;

        public OrdenController(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Orden
        public async Task<IActionResult> Index()
        {
            var libreriaDbContext = _context.Orden.Include(o => o.Cliente);
            return View(await libreriaDbContext.ToListAsync());
        }

        // GET: Orden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Orden/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId");
            return View();
        }

        // POST: Orden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenId,FechaOrden,Cantidad,ClienteId")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", orden.ClienteId);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", orden.ClienteId);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenId,FechaOrden,Cantidad,ClienteId")] Orden orden)
        {
            if (id != orden.OrdenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.OrdenId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", orden.ClienteId);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orden == null)
            {
                return Problem("Entity set 'LibreriaDbContext.Orden'  is null.");
            }
            var orden = await _context.Orden.FindAsync(id);
            if (orden != null)
            {
                _context.Orden.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
          return (_context.Orden?.Any(e => e.OrdenId == id)).GetValueOrDefault();
        }
    }
}
