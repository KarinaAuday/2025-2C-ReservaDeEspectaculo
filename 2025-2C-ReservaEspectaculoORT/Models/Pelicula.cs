using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
  
    public class Pelicula
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        
        public DateTime FechaLanzamiento { get; set; }

        
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public string Foto { get; set; }
       
        public List<Funcion> Funciones { get; set; } = new List<Funcion>();

        public Genero Genero { get; set; }

        public Pelicula (string descripcion, string titulo, DateTime fechaLanzamiento, string foto, Genero genero)
        {
            Descripcion = descripcion;
            Titulo = titulo;
            FechaLanzamiento = fechaLanzamiento;
            Foto = foto;
            Genero = genero;
            Funciones = new List<Funcion>();
        }
        public Pelicula()
        {
            
        }
    }

}
