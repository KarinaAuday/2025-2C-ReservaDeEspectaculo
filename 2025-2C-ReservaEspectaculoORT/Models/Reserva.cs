namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Reserva
    {
        public bool Activa { get; set; }
        public int CantidadButacas { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int FuncionId { get; set; }
        public int Id { get; set; }
    }
}
