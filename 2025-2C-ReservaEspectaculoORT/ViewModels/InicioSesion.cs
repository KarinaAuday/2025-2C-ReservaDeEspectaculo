using _2025_2C_ReservaEspectaculoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_ReservaEspectaculoORT.ViewModels
{
    public class InicioSesion
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = ErrorMsg.Invalido)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
