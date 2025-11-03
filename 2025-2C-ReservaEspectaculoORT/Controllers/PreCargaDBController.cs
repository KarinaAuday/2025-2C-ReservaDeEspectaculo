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
            new Cliente {Nombre = "Zakiel", Apellido = "Gimenez", Direccion="Cordoba 1788", Dni="45676789", Email="zaki@gmail.com", Telefono="299424920", UserName="zakielgocool" },
            new Cliente {Nombre = "Hector", Apellido = "De la Fuente", Direccion="Libertador 9738", Dni="47890766", Email="hectordlf@gmail.com", Telefono="83488484", UserName="coolhectordlf" },
            new Cliente {Nombre = "Martina", Apellido = "Bullon", Direccion="Av San Martin 1400", Dni="45898456", Email="martubullon@gmail.com", Telefono="299424920", UserName="martubulloncool" },
            new Cliente {Nombre = "Sofia", Apellido = "Olguin", Direccion="Av Cramer 1690", Dni="45676789", Email="sofiolg@gmail.com", Telefono="46898645", UserName="sofiolgcool" }
       
        };

        private List<Pelicula> peliculas = new List<Pelicula>
        {
            new ("pelicula de snoopy", "snoopy and charlie brown", new DateTime (2004,12,3), "aca va url foto",  Genero.Familiar),
            new ("pelicula atrapante del hombre arania", "Spiderman", new DateTime(2001,04,4), "aca va 2do url", Genero.Accion),
            new ("pelicula fantastica del ninio que vivio", "Harry Potter y la piedra filosofal", new DateTime(1997,4,6),"aca 3er url", Genero.Fantasia),
            new ("pelicula del estudio ghibili de una criatura muy amigable", "Mi vecino Totoro", (2010,5,6),"aca va 4to url" ,Genero.Animacion)
            };
    }
}
