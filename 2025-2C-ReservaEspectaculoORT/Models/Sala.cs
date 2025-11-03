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
        public int Numero { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = ErrorMsg.SoloLetrasYNumeros)]
        public int TipoSalaId { get; set; }
        
        public TipoSala ? TipoSala { get; set; }

        public List<Funcion> Funciones { get; set; } = new List<Funcion>();

        public Sala(int cantButacas, int num, int tipoSalaId)
        {
            this.CapacidadButacas = cantButacas;
            this.Numero = num;
            this.TipoSalaId = tipoSalaId;
        }

        public Sala()
        {
            
        }

    }
}
