using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercyDevelopers.Models;

namespace MercyDevelopers.Controllers
{
    public class ClienteHasServiciosController : Controller
    {
        private readonly MercyDevelopersContext _context;

        public ClienteHasServiciosController(MercyDevelopersContext context)
        {
            _context = context;
        }

        // GET: ClienteHasServicios
        public async Task<IActionResult> Index()
        {
            var mercyDevelopersContext = _context.ClienteHasServicios.Include(c => c.IdClienteNavigation).Include(c => c.IdServiciosNavigation);
            return View(await mercyDevelopersContext.ToListAsync());
        }

        // GET: ClienteHasServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteHasServicio = await _context.ClienteHasServicios
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdServiciosNavigation)
                .FirstOrDefaultAsync(m => m.IdClienteHasServicios == id);
            if (clienteHasServicio == null)
            {
                return NotFound();
            }

            return View(clienteHasServicio);
        }

        // GET: ClienteHasServicios/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdServicios"] = new SelectList(_context.Servicios, "IdServicios", "IdServicios");
            return View();
        }

        // POST: ClienteHasServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteHasServicios,IdCliente,IdServicios")] ClienteHasServicio clienteHasServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteHasServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", clienteHasServicio.IdCliente);
            ViewData["IdServicios"] = new SelectList(_context.Servicios, "IdServicios", "IdServicios", clienteHasServicio.IdServicios);
            return View(clienteHasServicio);
        }

        // GET: ClienteHasServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteHasServicio = await _context.ClienteHasServicios.FindAsync(id);
            if (clienteHasServicio == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", clienteHasServicio.IdCliente);
            ViewData["IdServicios"] = new SelectList(_context.Servicios, "IdServicios", "IdServicios", clienteHasServicio.IdServicios);
            return View(clienteHasServicio);
        }

        // POST: ClienteHasServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteHasServicios,IdCliente,IdServicios")] ClienteHasServicio clienteHasServicio)
        {
            if (id != clienteHasServicio.IdClienteHasServicios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteHasServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteHasServicioExists(clienteHasServicio.IdClienteHasServicios))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", clienteHasServicio.IdCliente);
            ViewData["IdServicios"] = new SelectList(_context.Servicios, "IdServicios", "IdServicios", clienteHasServicio.IdServicios);
            return View(clienteHasServicio);
        }

        // GET: ClienteHasServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteHasServicio = await _context.ClienteHasServicios
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdServiciosNavigation)
                .FirstOrDefaultAsync(m => m.IdClienteHasServicios == id);
            if (clienteHasServicio == null)
            {
                return NotFound();
            }

            return View(clienteHasServicio);
        }

        // POST: ClienteHasServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteHasServicio = await _context.ClienteHasServicios.FindAsync(id);
            if (clienteHasServicio != null)
            {
                _context.ClienteHasServicios.Remove(clienteHasServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteHasServicioExists(int id)
        {
            return _context.ClienteHasServicios.Any(e => e.IdClienteHasServicios == id);
        }
    }
}
