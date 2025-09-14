using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class TipoSala
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = ErrorMsg.StringLenght)]
        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^([1-9]\d*)(\.\d+)?$", ErrorMessage = ErrorMsg.SoloNumeros)]
        public double Precio { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        public List<Sala> Salas { get; set; }
    }
}
