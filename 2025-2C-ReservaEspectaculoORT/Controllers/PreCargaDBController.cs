using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Helpers;
using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{
    public class PreCargaDBController : Controller
    {
        private readonly ReservaEspectaculoContext _context;
        private readonly RoleManager<Rol> _roleManager;
        private readonly UserManager<Persona> _userManager;
        private List<string> roles = new List<string>
        {
            Configs.Admin,
            Configs.Empleado,
            Configs.Cliente
        };

        public PreCargaDBController(UserManager<Persona> userManager, RoleManager<Rol> roleManager, ReservaEspectaculoContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            _context = context;
        }

        private List<Cliente> clientes = new List<Cliente>
        {
            new Cliente {Nombre = "Zakiel", Apellido = "Gimenez", Direccion="Cordoba 1788", Dni="45676789", Email="cliente1@ort.edu.ar", Telefono="299424920" },
            new Cliente {Nombre = "Hector", Apellido = "De la Fuente", Direccion="Libertador 9738", Dni="47890766", Email="cliente2@ort.edu.ar", Telefono="83488484" },
            new Cliente {Nombre = "Martina", Apellido = "Bullon", Direccion="Av San Martin 1400", Dni="45898456", Email="cliente3@ort.edu.ar", Telefono="299424920"},
            new Cliente {Nombre = "Sofia", Apellido = "Olguin", Direccion="Av Cramer 1690", Dni="45676789", Email="cliente4@ort.edu.ar", Telefono="46898645"}
            
        };

        private List<Empleado> empleados = new List<Empleado>
        {
            new Empleado {Nombre = "Norma", Apellido = "Gonzales", Direccion="Vidal 1788", Dni="45698789", Email="empleado1@ort.edu.ar", Telefono="89864398", Legajo = 1 },
            new Empleado {Nombre = "Leon", Apellido = "Juarez", Direccion="Pampa 5090", Dni="43567421", Email="empleado2@ort.edu.ar", Telefono="896543276", Legajo = 2 },

        };

        private List<Pelicula> peliculas = new List<Pelicula>
        {
            new Pelicula("Snoopy y su inseparable pájaro Emilio persiguen a su gran enemigo, el Barón Rojo. Mientras tanto, su mejor amigo, Charlie Brown, " +
                "se embarca a su vez en una aventura de proporciones épicas.", "Snoopy y Charlie Brown", new DateTime (2004,12,3), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnVRqs_-J4GTDN5GAI1sgATxdU1I7xwg-XSQ&s",  Genero.Familiar),
            new Pelicula("Luego de sufrir la picadura de una araña genéticamente modificada, un estudiante de secundaria tímido y torpe adquiere increíbles capacidades como arácnido. " +
                "Pronto comprenderá que su misión es utilizarlas para luchar contra el mal y defender a sus vecinos.", "Spiderman", new DateTime(2001,04,4), "https://m.media-amazon.com/images/M/MV5BNmY2YmE3NzgtYTE3Ny00MGY0LTk0MmQtYTI5NTc0MDQ5ZmM4XkEyXkFqcGc@._V1_.jpg", Genero.Accion),
            new Pelicula("Durante su primer año en la escuela de magia y hechicería de Hogwarts, Harry Potter descubre que un malévolo y poderoso mago" +
                " llamado Voldemort está en busca de una piedra filosofal que alarga la vida de quien la posee.", "Harry Potter y la piedra filosofal", new DateTime(1997,4,6),"https://estaticos-cdn.prensaiberica.es/clip/faf42983-8792-46e1-8b1b-9a7b50cfdeee_alta-libre-aspect-ratio_default_0.jpg", Genero.Fantasia),
            new Pelicula("Esta historia animada del director Hayao Miyazaki sigue a las estudiantes y hermanas Satsuke y Mei mientras se establecen en su casa de campo con su padre y esperan a que su madre se recupere de una enfermedad en un hospital del área. " +
                "Cuando las hermanas exploran su nueva casa, descubren y hacen amistad con unos duendes juguetones.", "Mi vecino Totoro",new DateTime(2010,5,6),"https://pics.filmaffinity.com/Mi_vecino_Totoro-520161596-large.jpg" ,Genero.Animacion)
        };



        private void inicializarFunciones()
        {
            #region Crear TipoSala y Sala
            TipoSala Ts1 = new TipoSala { Nombre = "Sala 2D", Precio = 500 };
            _context.TipoSala.Add(Ts1);
            _context.SaveChanges();
            TipoSala Ts2 = new TipoSala { Nombre = "Sala 3D", Precio = 800 };
            _context.TipoSala.Add(Ts2);
            _context.SaveChanges();

            Sala s1 = new Sala(200, 1, Ts1.Id);
            _context.Sala.Add(s1);
            _context.SaveChanges();
            Sala s2 = new Sala(150, 2, Ts2.Id);
            _context.Sala.Add(s2);
            _context.SaveChanges();
            #endregion

            DateTime ahora = DateTime.Now;
            DateTime noDisponible = DateTime.Now.AddDays(9);

            #region Crear Funciones
            Funcion f1 = new Funcion(100, true, generarDescripcionFuncion(peliculas[0], s1), noDisponible, s1, peliculas[0], peliculas[0].Id, s1.Id);
            Funcion f2 = new Funcion(80, true, generarDescripcionFuncion(peliculas[1], s2), ahora, s2, peliculas[1], peliculas[1].Id, s2.Id);
            Funcion f3 = new Funcion(120, true, generarDescripcionFuncion(peliculas[2], s1), ahora, s1, peliculas[2], peliculas[2].Id, s1.Id);
            Funcion f4 = new Funcion(90, true, generarDescripcionFuncion(peliculas[3], s2), ahora, s2, peliculas[3], peliculas[3].Id, s2.Id);

            _context.Funcion.Add(f1);
            _context.Funcion.Add(f2);
            _context.Funcion.Add(f3);
            _context.Funcion.Add(f4);
            _context.SaveChanges();

            peliculas[0].Funciones.Add(f1);
            peliculas[1].Funciones.Add(f2);
            peliculas[2].Funciones.Add(f3);
            peliculas[3].Funciones.Add(f4);
            _context.SaveChanges();
            #endregion

            #region Crear Reservas
            //Reserva r1 = new Reserva(2, clientes[0].id, f1.Id);
            //_context.Reserva.Add(r1);
            //_context.SaveChanges();
            //Reserva r2 = new Reserva(1, clientes[1].id, f2.Id);
            //_context.Reserva.Add(r2);
            //_context.SaveChanges();
            #endregion
        }

        private string generarDescripcionFuncion(Pelicula pelicula, Sala sala)
        {
            return $"{pelicula.Titulo} - {sala.TipoSala.Nombre}";
        }

        private async Task crearClientes()
        {
            //foreach (var Cliente in clientes)
            //{
            //    Cliente.UserName = Cliente.Email;
            //    await _userManager.CreateAsync(Cliente, Configs.PasswordGenerica);
            //    await _userManager.AddToRoleAsync(Cliente, Configs.Cliente);
            //}


            Cliente c1 = new Cliente() { Nombre = "Zakiel", Apellido = "Gimenez", Direccion = "Cordoba 1788", Dni = "45676789", Email = "cliente1@ort.edu.ar", Telefono = "299424920" };
            c1.UserName = c1.Email;
            await _userManager.CreateAsync(c1, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(c1, "Cliente");

            Cliente c2 = new Cliente() { Nombre = "Hector", Apellido = "De la Fuente", Direccion = "Libertador 9738", Dni = "47890766", Email = "cliente2@ort.edu.ar", Telefono = "83488484" };
            c2.UserName = c2.Email;
            await _userManager.CreateAsync(c2, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(c2, "Cliente");

            Cliente c3 = new Cliente() { Nombre = "Martina", Apellido = "Bullon", Direccion = "Av San Martin 1400", Dni = "45898456", Email = "cliente3@ort.edu.ar", Telefono = "299424920" };
            c3.UserName = c3.Email;
            await _userManager.CreateAsync(c3, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(c3, "Cliente");

            Cliente c4 = new Cliente() { Nombre = "Sofia", Apellido = "Olguin", Direccion = "Av Cramer 1690", Dni = "45676789", Email = "cliente4@ort.edu.ar", Telefono = "46898645" };
            c4.UserName = c4.Email;
            await _userManager.CreateAsync(c4, Configs.PasswordGenerica);
            await _userManager.AddToRoleAsync(c4, "Cliente");
        }


        private async Task crearEmpleados()
        {
           foreach (var Empleado in empleados)
            {
                Empleado.UserName = Empleado.Email;
                await _userManager.CreateAsync(Empleado, Configs.PasswordGenerica);
                await _userManager.AddToRoleAsync(Empleado, Configs.Empleado);
            }
           
        }

        private void crearPeliculas()
        {
            //foreach(var Pelicula in peliculas)
            // {
            //     _context.Pelicula.Add(Pelicula);
            //     _context.SaveChanges();
            // }

            Pelicula p1 = new Pelicula("Snoopy y su inseparable pájaro Emilio persiguen a su gran enemigo, el Barón Rojo. Mientras tanto, su mejor amigo, Charlie Brown, " +
                 "se embarca a su vez en una aventura de proporciones épicas.", "Snoopy y Charlie Brown", new DateTime(2004, 12, 3), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnVRqs_-J4GTDN5GAI1sgATxdU1I7xwg-XSQ&s", Genero.Familiar);

            _context.Pelicula.Add(p1);
            _context.SaveChanges();


        }

        private void precargarProgramacion()
        {
            Pelicula p1 = new Pelicula("Snoopy y su inseparable pájaro Emilio persiguen a su gran enemigo, el Barón Rojo. Mientras tanto, su mejor amigo, Charlie Brown, " +
                 "se embarca a su vez en una aventura de proporciones épicas.", "Snoopy y Charlie Brown", new DateTime(2004, 12, 3), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnVRqs_-J4GTDN5GAI1sgATxdU1I7xwg-XSQ&s", Genero.Familiar);
            _context.Pelicula.Add(p1);
            _context.SaveChanges();

            Pelicula p2 = new Pelicula("Luego de sufrir la picadura de una araña genéticamente modificada, un estudiante de secundaria tímido y torpe adquiere increíbles capacidades como arácnido. " +
                "Pronto comprenderá que su misión es utilizarlas para luchar contra el mal y defender a sus vecinos.", "Spiderman", new DateTime(2001, 04, 4), "https://m.media-amazon.com/images/M/MV5BNmY2YmE3NzgtYTE3Ny00MGY0LTk0MmQtYTI5NTc0MDQ5ZmM4XkEyXkFqcGc@._V1_.jpg", Genero.Accion);
            _context.Pelicula.Add(p2);
            _context.SaveChanges();

            Pelicula p3 = new Pelicula("Durante su primer año en la escuela de magia y hechicería de Hogwarts, Harry Potter descubre que un malévolo y poderoso mago" +
                " llamado Voldemort está en busca de una piedra filosofal que alarga la vida de quien la posee.", "Harry Potter y la piedra filosofal", new DateTime(1997, 4, 6), "https://estaticos-cdn.prensaiberica.es/clip/faf42983-8792-46e1-8b1b-9a7b50cfdeee_alta-libre-aspect-ratio_default_0.jpg", Genero.Fantasia);
            _context.Pelicula.Add(p3);
            _context.SaveChanges();

            Pelicula p4 = new Pelicula("Esta historia animada del director Hayao Miyazaki sigue a las estudiantes y hermanas Satsuke y Mei mientras se establecen en su casa de campo con su padre y esperan a que su madre se recupere de una enfermedad en un hospital del área. " +
               "Cuando las hermanas exploran su nueva casa, descubren y hacen amistad con unos duendes juguetones.", "Mi vecino Totoro", new DateTime(2010, 5, 6), "https://pics.filmaffinity.com/Mi_vecino_Totoro-520161596-large.jpg", Genero.Animacion);
            _context.Pelicula.Add(p4);
            _context.SaveChanges();

            TipoSala Ts1 = new TipoSala { Nombre = "Sala 2D", Precio = 500 };
            _context.TipoSala.Add(Ts1);
            _context.SaveChanges();

            TipoSala Ts2 = new TipoSala { Nombre = "Sala 3D", Precio = 800 };
            _context.TipoSala.Add(Ts2);
            _context.SaveChanges();

            Sala s1 = new Sala(200, 1, Ts1.Id);
            _context.Sala.Add(s1);
            _context.SaveChanges();

            Sala s2 = new Sala(150, 2, Ts2.Id);
            _context.Sala.Add(s2);
            _context.SaveChanges();

            Funcion f1 = new Funcion(100, true, generarDescripcionFuncion(p1, s1), DateTime.Now.AddYears(1), s1, p1, p1.Id, s1.Id);
            _context.Funcion.Add(f1);
            _context.SaveChanges();

            Funcion f2 = new Funcion(100, true, generarDescripcionFuncion(p2, s2), DateTime.Now, s2, p2, p2.Id, s2.Id);
            _context.Funcion.Add(f2);
            _context.SaveChanges();
        }

        public IActionResult InicializarDB()
        {
            cargarRoles().Wait();
            crearClientes().Wait();
            crearEmpleados().Wait();
            //crearPeliculas();
            precargarProgramacion();
            return RedirectToAction("Index", "Home");
        }

        private async Task cargarRoles()
        {
            foreach (var r in roles)
            {
                if (!await _roleManager.RoleExistsAsync(r))
                {
                    await _roleManager.CreateAsync(new Rol(r));
                }
            }
        }
    }
}
