using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Funcion
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int ButacasDisponibles { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public bool Confirmada { get; set; }
        public string Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public Sala Sala { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public Pelicula Pelicula { get; set; }  
        public List<Reserva> Reservas { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int PeliculaId { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int SalaId { get; set; }
    }
}
