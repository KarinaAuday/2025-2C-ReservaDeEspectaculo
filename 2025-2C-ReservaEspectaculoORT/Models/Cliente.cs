using System.Transactions;

namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Cliente : Persona
    {
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public Cliente(string nombre, string apellido, string direccion, string dni, string email, DateTime fechaAlta, string telefono, string userName): base(nombre, apellido, direccion, dni, email, fechaAlta, telefono, userName)
        {
            this.Reservas = new List<Reserva>();
        }
    }
}
