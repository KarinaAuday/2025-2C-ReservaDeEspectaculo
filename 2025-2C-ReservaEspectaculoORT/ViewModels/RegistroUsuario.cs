using System.ComponentModel.DataAnnotations;
using _2025_2C_ReservaEspectaculoORT.Helpers;

namespace _2025_2C_ReservaEspectaculoORT.ViewModels
{
    public class RegistroUsuario
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [EmailAddress(ErrorMessage = ErrorMsg.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = ErrorMsg.Required)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ErrorMsg.Password)]
        public string ConfirmPassword { get; set; }
    }
}
