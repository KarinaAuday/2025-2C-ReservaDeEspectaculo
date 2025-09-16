using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Sala
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int CapacidadButacas { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = ErrorMsg.SoloNumeros)]
        [StringLength(3, ErrorMessage = ErrorMsg.StringLenght)]
        public int Numero { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = ErrorMsg.SoloNumeros)]
        [StringLength(10, ErrorMessage = ErrorMsg.StringLenght)]
        public int TipoSalaId { get; set; }

        
        public TipoSala TipoSala { get; set; }
    }
}
