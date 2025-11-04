using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{
    public class PreCargaDBController : Controller
    {
        private readonly ReservaEspectaculoContext _context;

        public PreCargaDBController(ReservaEspectaculoContext context)
        {
            _context = context;
        }

        private List<Cliente> clientes = new List<Cliente>
        {
            new Cliente {Nombre = "Zakiel", Apellido = "Gimenez", Direccion="Cordoba 1788", Dni="45676789", Email="cliente1@ort.edu.ar", Telefono="299424920", UserName="cliente1" },
            new Cliente {Nombre = "Hector", Apellido = "De la Fuente", Direccion="Libertador 9738", Dni="47890766", Email="cliente2@ort.edu.ar", Telefono="83488484", UserName="cliente2" },
            new Cliente {Nombre = "Martina", Apellido = "Bullon", Direccion="Av San Martin 1400", Dni="45898456", Email="cliente3@ort.edu.ar", Telefono="299424920", UserName="cliente3" },
            new Cliente {Nombre = "Sofia", Apellido = "Olguin", Direccion="Av Cramer 1690", Dni="45676789", Email="cliente4@ort.edu.ar", Telefono="46898645", UserName="cliente4" }

        };

        private List<Empleado> empleados = new List<Empleado>
        {
            new Empleado {Nombre = "Norma", Apellido = "Gonzales", Direccion="Vidal 1788", Dni="45698789", Email="empleado1@ort.edu.ar", Telefono="89864398", UserName="empleado1", Legajo = 1 },
            new Empleado {Nombre = "Leon", Apellido = "Juarez", Direccion="Pampa 5090", Dni="43567421", Email="empleado2@ort.edu.ar", Telefono="896543276", UserName="empleado2", Legajo = 2 },

        };

        private List<Pelicula> peliculas = new List<Pelicula>
        {
            new Pelicula("pelicula de snoopy", "snoopy and charlie brown", new DateTime (2004,12,3), "~/img/snoopy.png",  Genero.Familiar),
            new Pelicula("pelicula atrapante del hombre arania", "Spiderman", new DateTime(2001,04,4), "~/img/spiderman.png", Genero.Accion),
            new Pelicula("pelicula fantastica del ninio que vivio", "Harry Potter y la piedra filosofal", new DateTime(1997,4,6),"~/img/harry-potter.png", Genero.Fantasia),
            new Pelicula("pelicula del estudio ghibili de una criatura muy amigable", "Mi vecino Totoro",new DateTime(2010,5,6),"~/img/mi-vecino-totoro.jpg" ,Genero.Animacion)
        };

       

        private void inicializarFunciones()
        {
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

            Funcion f1 = new Funcion(100, true, "Funcion de la pelicula snoopy", new DateTime(2025, 7, 10, 18, 30, 0), peliculas[0].Id, s1.Id);
            Funcion f2 = new Funcion(80, true, "Funcion de la pelicula spiderman", new DateTime(2025, 12, 11, 20, 0, 0), peliculas[1].Id, s2.Id);
            Funcion f3 = new Funcion(120, true, "Funcion de la pelicula harry potter", new DateTime(2025, 7, 12, 16, 0, 0), peliculas[2].Id, s1.Id);
            Funcion f4 = new Funcion(90, true, "Funcion de la pelicula totoro", new DateTime(2025, 7, 13, 19, 30, 0), peliculas[3].Id, s2.Id);

            _context.Funcion.Add(f1);
            _context.Funcion.Add(f2);
            _context.Funcion.Add(f3);
            _context.Funcion.Add(f4);
            _context.SaveChanges();

            Reserva r1 = new Reserva { CantidadButacas = 2, ClienteId = clientes[0].id, FuncionId = f1.Id };
            _context.Reserva.Add(r1);
            _context.SaveChanges();
            Reserva r2 = new Reserva { CantidadButacas = 1, ClienteId = clientes[1].id, FuncionId = f2.Id };
            _context.Reserva.Add(r2);
            _context.SaveChanges();
        }

        private void crearClientes()
        {
           foreach(var Cliente in clientes)
            {
                _context.Cliente.Add(Cliente);
                _context.SaveChanges();
            }

        }


        private void crearEmpleados()
        {
           foreach (var Empleado in empleados)
            {
                _context.Empleado.Add(Empleado);
                _context.SaveChanges();
            }
           
        }

        private void crearPeliculas()
        {
           foreach(var Pelicula in peliculas)
            {
                _context.Pelicula.Add(Pelicula);
                _context.SaveChanges();
            }
            
        }
        public IActionResult InicializarDB()
        {
            crearClientes();
            crearEmpleados();
            crearPeliculas();
            inicializarFunciones();
            return RedirectToAction("Index", "Home");
        }
    }
}
