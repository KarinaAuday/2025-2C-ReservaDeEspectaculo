using _2025_2C_ReservaEspectaculoORT.Helpers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Persona : IdentityUser<int>
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = ErrorMsg.SoloLetras)]
        public string Nombre { get; set; }

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
        public override string Email
        {
            get => base.Email;
            set => base.Email = value;
        }
        
        public DateTime FechaAlta { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        //[Required(ErrorMessage = ErrorMsg.Required)]
        //[StringLength(10, ErrorMessage = ErrorMsg.StringLenght)]
       //public string UserName { get; set; }


        /* public Persona(string nombre, string apellido, string direccion, string dni, string email, DateTime fechaAlta, string telefono, string userName)
         {
             this.Nombre = nombre;
             this.Apellido = apellido;
             this.Direccion = direccion;
             this.Dni = dni;
             this.Email = email;
             this.FechaAlta = fechaAlta;
             this.UserName = userName;

         }*/
    }
}
