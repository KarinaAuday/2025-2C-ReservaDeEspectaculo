using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Empleado : Persona
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^([0-9]\d*)(\.\d+)?$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public int Legajo { get; set; }
    }
}
