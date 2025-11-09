using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public bool Activa { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int CantidadButacas { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public DateTime FechaAlta { get; set; }
        public Cliente ? Cliente { get; set; }
        public Funcion ? Funcion { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^\d+$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int FuncionId { get; set; }

        public Reserva(int cantButacas, int idCliente, int idFuncion)
        {
            this.CantidadButacas = cantButacas;
            this.Activa = true;
            this.ClienteId = idCliente;
            this.FuncionId = idFuncion;
        }

        public Reserva()
        {
            
        }
    }
}
