using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
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
    public class ClientesController : Controller
    {
        private readonly ReservaEspectaculoContext _context;
        private readonly UserManager<Persona> _userManager;
        public ClientesController(ReservaEspectaculoContext context, UserManager<Persona> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.Include(c=>c.Reservas).ThenInclude(r=>r.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public async Task<IActionResult> Perfil()
        {
            int id = int.Parse(_userManager.GetUserId(User));

            var cliente = await _context.Cliente.Include(c => c.Reservas).ThenInclude(r => r.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("Details", cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apellido,Direccion,Dni,Email,FechaAlta,Nombre,Telefono,UserName")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.FechaAlta = DateTime.Now;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apellido,Direccion,Dni,Email,FechaAlta,Nombre,Telefono,UserName")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cli = _context.Cliente.Find(cliente.Id);
                    if (cli == null)
                    {
                        return NotFound();
                    }
                    cli.Nombre = cliente.Nombre;
                    cli.Apellido = cliente.Apellido;
                    cli.Direccion = cliente.Direccion;
                    cli.FechaAlta = DateTime.Now;
                    cli.Telefono = cliente.Telefono;
                    cli.UserName = cliente.UserName;

                    _context.Update(cli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View("Index", "Home");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,Apellido,Direccion,Dni,Email,FechaAlta,Nombre,Telefono,UserName")] Cliente cliente)
        //{
        //    if (id != cliente.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cliente);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClienteExists(cliente.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cliente);
        //} 


        public async Task<IActionResult> CompletarDatos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletarDatos(int id, [Bind("Id,Apellido,Direccion,Dni,Email,FechaAlta,Nombre,Telefono,UserName")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cli = _context.Cliente.Find(cliente.Id);
                    if (cli == null)
                    {
                        return NotFound();
                    }
                    cli.Nombre = cliente.Nombre;
                    cli.Apellido = cliente.Apellido;
                    cli.Direccion = cliente.Direccion;
                    cli.FechaAlta = DateTime.Now;
                    cli.Telefono = cliente.Telefono;
                    cli.UserName = cliente.UserName;
                    cli.Dni = cliente.Dni;

                    _context.Update(cli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = cliente.Id });
            }
            return RedirectToAction(nameof(Index));
        }



        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
        public ActionResult Buscar(string? nombre)
        {
            if (!String.IsNullOrEmpty(nombre))
            {
                var clientes = _context.Cliente.Include(p=>p.Reservas).ThenInclude(r=>r.Funcion).Where(p => p.Nombre.ToUpper().Contains(nombre.ToUpper())||p.Apellido.ToUpper().Contains(nombre.ToUpper())).ToList();
                if (clientes.Count == 0)
                {
                    ViewBag.Mensaje = "No se encontraron resultados";
                }
                return View("Buscador", clientes);
            }
            else
            {
                return View("Buscador");
            }
        }
        // GET: muestra el formulario
        //[HttpGet]
        //public async Task<IActionResult> Reserva(int idCliente)
        //{
        //    ViewBag.Titulo = new SelectList(_context.Pelicula, "Id", "Titulo");
        //    return View();
        //}

        //// POST: recibe los datos del formulario
        //[HttpPost]
        //public async Task<IActionResult> Reserva(int id, int cantButacas)
        //{
        //    TempData["cantButacas"] = cantButacas;

        //    return RedirectToAction("ListarFunciones", new { idPelicula = id });
        //}

        //public IActionResult ListarFunciones(int idPelicula)
        //{
        //    var pelicula = _context.Pelicula.FirstOrDefault(p => p.Id == idPelicula);

        //    if (pelicula == null)
        //        return NotFound();


        //    ViewBag.Pelicula = pelicula;
        //    ViewBag.ListaFunciones = new List<Funcion>(pelicula.Funciones); 
        //    ViewBag.CantButacas = TempData["cantButacas"];

        //    return View();
        //}
    }
}
