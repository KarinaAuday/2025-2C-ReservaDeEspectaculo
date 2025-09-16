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
        
        public DateTime FechaLanzaiento { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public string Foto { get; set; }
       
        public List<Funcion> Funciones { get; set; } = [];

        public Genero Genero { get; set; }
    }
}
