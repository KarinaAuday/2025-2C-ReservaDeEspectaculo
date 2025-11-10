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

            //peliculas[0].Funciones.Add(f1);
            //peliculas[1].Funciones.Add(f2);
            //peliculas[2].Funciones.Add(f3);
            //peliculas[3].Funciones.Add(f4);
            //_context.SaveChanges();
            #endregion

            #region Crear Reservas
            Reserva r1 = new Reserva(2, clientes[0].id, f1.Id);
            _context.Reserva.Add(r1);
            _context.SaveChanges();
            Reserva r2 = new Reserva(1, clientes[1].id, f2.Id);
            _context.Reserva.Add(r2);
            _context.SaveChanges();
            #endregion
        }

        private string generarDescripcionFuncion(Pelicula pelicula, Sala sala)
        {
            return $"{pelicula.Titulo} - {sala.TipoSala.Nombre}";
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
