namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public bool Activa { get; set; }
        public int CantidadButacas { get; set; }
        public DateTime FechaAlta { get; set; }
        public Cliente Cliente { get; set; }
        public Funcion Funcion { get; set; }
        public int ClienteId { get; set; }
        public int FuncionId { get; set; }
    }
}
