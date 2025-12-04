using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using _2025_2C_ReservaEspectaculoORT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{
    public class AccountController : Controller
    {
        private readonly ReservaEspectaculoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signInManager;
        private readonly RoleManager<Rol> _roleManager;

        public AccountController(UserManager<Persona> userManager, SignInManager<Persona> signInManager, RoleManager<Rol> rolManager, ReservaEspectaculoContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = rolManager;
            _context = context;

        }

        public IActionResult Registrar()
        {   
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("Email", "Password", "ConfirmPassword")]RegistroUsuario u)
        {
            if (ModelState.IsValid)
            {
                Cliente c = new Cliente();
                c.Email = u.Email;
                c.UserName = u.Email;
                var resultadoCliente = await _userManager.CreateAsync(c, u.Password);

                if (resultadoCliente.Succeeded)
                {
                    var resultadoAddRole = await _userManager.AddToRoleAsync(c, "Cliente"); 

                    if (resultadoAddRole.Succeeded)
                    {
                        await _signInManager.SignInAsync(c, isPersistent: false);
                        return RedirectToAction("CompletarDatos", "Clientes", new { id = c.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se pudo asignar el rol al usuario.");  
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { mensajeError = "Usuario duplicado o error al crear el usuairo" });
                }
            }
            return View(u);
        }

        [Authorize(Roles = "Empleado, Admin")]
        public IActionResult RegistrarEmpleado()
        {
            return View();
        }

        [Authorize(Roles = "Empleado, Admin")]
        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado([Bind("Email", "Password", "ConfirmPassword")] RegistroUsuario u)
        {
            if (ModelState.IsValid)
            {
                Empleado e = new Empleado();
                e.Email = u.Email;
                e.UserName = u.Email;
                var resultadoCliente = await _userManager.CreateAsync(e, u.Password);

                if (resultadoCliente.Succeeded)
                {
                    var resultadoAddRole = await _userManager.AddToRoleAsync(e, "Empleado");

                    if (resultadoAddRole.Succeeded)
                    {
                        await _signInManager.SignInAsync(e, isPersistent: false);

                        return RedirectToAction("CompletarDatos", "Empleados", new { id = e.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se pudo asignar el rol al empleado.");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { mensajeError = "Empleado duplicado o error al crear el usuairo" });
                }
            }
            return View(u);
        }

        public IActionResult IniciarSesion(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(InicioSesion inicio)
        {

            if (ModelState.IsValid)
            {
                string returnUrl = TempData["ReturnUrl"] as string;
                var resultado = await _signInManager.PasswordSignInAsync(inicio.Email, inicio.Password, inicio.Recordarme, false);

                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, "Inicio de Sesión inválida");
            }
            return View(inicio);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> IniciarSesionConPelicula(string returnUrl, int idPeli)
        {
            TempData["ReturnUrl"] = returnUrl;
            var pelicula = await _context.Pelicula.FindAsync(idPeli);
            ViewBag.idPelicula = pelicula?.Id;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IniciarSesionConPelicula(InicioSesion inicio, int idPelicula)
        {

            if (ModelState.IsValid)
            {
                string returnUrl = TempData["ReturnUrl"] as string;
              
                var resultado = await _signInManager.PasswordSignInAsync(inicio.Email, inicio.Password, inicio.Recordarme, false);
                int idCliente = int.Parse(_userManager.GetUserId(User));

                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("SeleccionarButacas", "Reservas", new { idPelicula, idCliente });
                }

                ModelState.AddModelError(String.Empty, "Inicio de Sesión inválida");
            }
            return View(inicio);
        }
     
    }
}
