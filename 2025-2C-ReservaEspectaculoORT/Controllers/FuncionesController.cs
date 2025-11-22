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
    public class FuncionesController : Controller
    {
        private readonly ReservaEspectaculoContext _context;

        public FuncionesController(ReservaEspectaculoContext context)
        {
            _context = context;
        }

        // GET: Funciones
        public async Task<IActionResult> Index()
        {
            var reservaEspectaculoContext = _context.Funcion.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await reservaEspectaculoContext.ToListAsync());
        }
        public async Task<IActionResult> ListarReservasFuturo()
        {
            var reservaEspectaculoContext = _context.Funcion.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await reservaEspectaculoContext.ToListAsync());
        }
        public async Task<IActionResult> ListaReservasPasado()
        {
            var reservaEspectaculoContext = _context.Funcion.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await reservaEspectaculoContext.ToListAsync());
        }


        // GET: Funciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // GET: Funciones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Id");
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id");
            return View();
        }

        // POST: Funciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ButacasDisponibles,Confirmada,Descripcion,Fecha,PeliculaId,SalaId")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Set<Pelicula>(), "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Set<Pelicula>(), "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // POST: Funciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ButacasDisponibles,Confirmada,Descripcion,Fecha,PeliculaId,SalaId")] Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionExists(funcion.Id))
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
            ViewData["PeliculaId"] = new SelectList(_context.Set<Pelicula>(), "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // POST: Funciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion != null)
            {
                _context.Funcion.Remove(funcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
            return _context.Funcion.Any(e => e.Id == id);
        }

        // GET: muestra el formulario
        [HttpGet]
        public async Task<IActionResult> Reservar()
        {
            ViewBag.Titulo = new SelectList(_context.Pelicula, "Id", "Titulo");

            return View();
        }

        // POST: recibe los datos del formulario
        [HttpPost]
        public async Task<IActionResult> Reservar(int id, int cantButacas)
        {

            return RedirectToAction("ListarFunciones", new { idPelicula = id, CantButacas = cantButacas });
        }

        public async Task<IActionResult> ListarFunciones(int idPelicula, int CantButacas)
        {
            var pelicula = await _context.Pelicula.Include(p => p.Funciones).ThenInclude(f => f.Sala).ThenInclude(s => s.TipoSala).FirstOrDefaultAsync(p => p.Id == idPelicula);

            if (pelicula == null)
                return NotFound();

            ViewBag.Pelicula = pelicula;
            ViewBag.CantButacas = CantButacas;

            return View(pelicula);
        }

    }
}
