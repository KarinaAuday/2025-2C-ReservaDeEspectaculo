using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{

    public class ReservasController : Controller
    {
        private readonly ReservaEspectaculoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol>_roleManager;
        private readonly SignInManager<Persona> _signInManager;


        public ReservasController(ReservaEspectaculoContext context, UserManager<Persona> userManager, SignInManager<Persona> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
    
        public IActionResult Create(int funcionId, int CantidadButacas, int idCliente)
        {
            ViewBag.ClienteId = idCliente;
            ViewBag.FuncionId = funcionId;
            ViewBag.CantButacas = CantidadButacas;

            var funcion = _context.Funcion.Include(f => f.Pelicula).FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null)
                return NotFound();

            ViewBag.Funcion = funcion;

            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Activa,CantidadButacas,ClienteId,FuncionId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.FechaAlta = DateTime.Now;

                var cliente = _context.Cliente.Include(c => c.Reservas).FirstOrDefault(c => c.Id == reserva.ClienteId);
                reserva.Cliente = cliente;
                cliente.Reservas.Add(reserva);

                var funcion = _context.Funcion.Include(f => f.Pelicula).FirstOrDefault(f => f.Id == reserva.FuncionId);
                funcion.ButacasDisponibles -= reserva.CantidadButacas;
                reserva.Funcion = funcion;

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Clientes", new { id = cliente.Id });
            }
            //ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "id", "Apellido", reserva.ClienteId);
            //ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Descripcion", reserva.FuncionId);
            return View(reserva);
        }

        // GET: Reservas/Generate
        public IActionResult GenerarReserva(int funcionId, int cantButacas)
        {
            ViewBag.CantButacas = cantButacas;
            var funcion = _context.Funcion.Include(f => f.Pelicula).FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null)
                return NotFound();

            ViewBag.Funcion = funcion;

            return View();
        }


        // POST: Reservas/Generate
        [HttpPost]
        public async Task<IActionResult> GenerarReserva(Reserva reserva)
        {

            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", "Home");
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "Id", "Apellido", reserva.ClienteId);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancelar(int id, int idCliente)
        {
            var reserva = await _context.Reserva.Include(r => r.Funcion).FirstOrDefaultAsync(r => r.Id == id);
            if (reserva != null)
            {
                reserva.Funcion.ButacasDisponibles += reserva.CantidadButacas;
                reserva.Activa = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Perfil", "Clientes");
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }


        // GET: Reservas
        public async Task<IActionResult> SeleccionarPelicula()
        {
            int idCliente = int.Parse(_userManager.GetUserId(User));
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (tieneReservaActiva(cliente))
            {
                ViewBag.Mensaje = "No puede realizar una nueva reserva porque ya tiene una reserva activa.";
            }
            ViewBag.Titulo = new SelectList(_context.Pelicula, "Id", "Titulo");
            ViewBag.IdCliente = idCliente;
            return View();
        }

        // GET: Reservas
        public async Task<IActionResult> SeleccionarPeliculaEmpleado(int idCliente)
        {
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (tieneReservaActiva(cliente))
            {
                ViewBag.Mensaje = "No puede realizar una nueva reserva porque ya tiene una reserva activa.";
            }
            ViewBag.Titulo = new SelectList(_context.Pelicula, "Id", "Titulo");
            ViewBag.IdCliente = idCliente;
            return View("SeleccionarPelicula");
        }

        private bool tieneReservaActiva(Cliente cliente)
        {
            var reservasActivas = _context.Reserva
                .Include(r => r.Funcion)
                .Where(r =>
                    r.ClienteId == cliente.Id &&
                    r.Activa &&
                    r.Funcion != null &&
                    r.Funcion.Fecha >= DateTime.Now
                )
                .Any();

            return reservasActivas;
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> SeleccionarPelicula(int id, int idCliente)
        {
            return RedirectToAction("SeleccionarButacas", "Reservas", new { idPelicula = id, idCliente });
        }

        public IActionResult SeleccionarPeliculaCartelera(int idPelicula) 
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("IniciarSesionConPelicula", "Account", new { idPeli = idPelicula });
            }
                int idCliente = int.Parse(_userManager.GetUserId(User));
                return RedirectToAction("SeleccionarButacas", new { idPelicula, idCliente });   
        }

        [HttpGet]
        public async Task<IActionResult> SeleccionarButacas(int idPelicula, int idCliente)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("IniciarSesionConPelicula", "Account", new { idPeli = idPelicula });
            }

            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (tieneReservaActiva(cliente))
            {
                ViewBag.Mensaje = "No puede realizar una nueva reserva porque ya tiene una reserva activa.";
            }
            var pelicula = await _context.Pelicula.FindAsync(idPelicula);
            ViewBag.PeliculaId = pelicula.Id;
            ViewBag.IdCliente = cliente.Id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SeleccionarButacas(int cantButacas, int id, int idCliente)
        {
            return RedirectToAction("ListarFunciones", "Funciones", new { idPelicula = id, CantButacas = cantButacas, idCliente });
        }
        public IActionResult ListarReservasFuturo()
        {
            var reservasf =  _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcion).Include(r=>r.Funcion.Pelicula).Where(r => r.Funcion.Fecha >= DateTime.Now).ToList();
           
            if (reservasf.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron resultados";
            }
            return View("ListarReservasFuturo",reservasf);
        }
        public IActionResult ListarReservasPasado()
        {
            var reservasp = _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcion).Include(r => r.Funcion.Pelicula).Where(r => r.Funcion.Fecha < DateTime.Now).ToList();

            if (reservasp.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron resultados";
            }
            return View("ListarReservasPasado", reservasp);

        }
    }
}
