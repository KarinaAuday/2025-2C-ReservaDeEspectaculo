using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Persona
    {
        public int id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [Display(Name = "Documento Nacional de Identidad")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = ErrorMsg.OchoDigitos)]
        public string Dni { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }

        [Required (ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Nombre { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [StringLength(10, ErrorMessage = ErrorMsg.StringLenght)]
        public string UserName { get; set; }
    }
}
