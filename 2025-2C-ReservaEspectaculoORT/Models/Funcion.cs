using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int ButacasDisponibles { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public bool Confirmada { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = ErrorMsg.TodoMenosEspaciosVacios)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public DateTime Fecha { get; set; }
        public Sala? Sala { get; set; }
        public Pelicula? Pelicula { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int PeliculaId { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int SalaId { get; set; }


        public Funcion(int butacasDisponibles, bool confirmada, string desc, DateTime fecha, Sala sala, Pelicula peli, int peliId, int salaId)
        {
            this.ButacasDisponibles = butacasDisponibles;
            this.Confirmada = confirmada;
            this.Descripcion = peli.Titulo+" - "+ sala.TipoSala.Nombre;
            this.Fecha = fecha;
            this.Sala = sala;
            this.Pelicula = peli;
            this.PeliculaId = peliId;
            this.SalaId = salaId;
        }

        public Funcion()
        {
            
        }
    }

    

    }
