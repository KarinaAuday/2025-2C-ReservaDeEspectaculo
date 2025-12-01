using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using _2025_2C_ReservaEspectaculoORT.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

    }
}
