using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ReservaEspectaculoContext _context;

        public ReservasController(ReservaEspectaculoContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservaEspectaculoContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcion);
            return View(await reservaEspectaculoContext.ToListAsync());
        }

        // public async Task<IActionResult> Reservar()

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "id", "Apellido");
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Descripcion");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Activa,CantidadButacas,FechaAlta,ClienteId,FuncionId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "id", "Apellido", reserva.ClienteId);
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Descripcion", reserva.FuncionId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "id", "Apellido", reserva.ClienteId);
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Descripcion", reserva.FuncionId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Activa,CantidadButacas,FechaAlta,ClienteId,FuncionId")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "id", "Apellido", reserva.ClienteId);
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Descripcion", reserva.FuncionId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }


        // GET: Reservas
        public async Task<IActionResult> SeleccionarPelicula()
        {
            ViewBag.Titulo = new SelectList(_context.Pelicula, "Id", "Titulo");
            return View();
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> SeleccionarPelicula(int id)
        {
            return RedirectToAction("SeleccionarButacas", "Reservas", new { idPelicula = id });
        }

        [HttpGet]
        public async Task<IActionResult> SeleccionarButacas(int idPelicula)
        {
            var pelicula = await _context.Pelicula.FindAsync(idPelicula);

            ViewBag.PeliculaId = pelicula.Id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SeleccionarButacas(int cantButacas, int id)
        {
            return RedirectToAction("ListarFunciones", "Funciones", new { idPelicula = id });
        }
    }
}
