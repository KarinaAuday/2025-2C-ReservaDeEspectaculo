namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Sala
    {
        public int CapacidadButacas { get; set; }

        public int Id { get; set; }

        public int Numero { get; set; }

        public int TipoSalaId { get; set; }

        public TipoSala TipoSala { get; set; }
    }
}
