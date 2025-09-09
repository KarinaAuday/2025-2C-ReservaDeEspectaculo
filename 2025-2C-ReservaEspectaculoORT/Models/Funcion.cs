namespace _2025_2C_ReservaEspectaculoORT.Models
{
    public class Funcion
    {
        public int Id { get; set; }
        public int ButacasDisponibles { get; set; }
        public bool Confirmada { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Sala Sala { get; set; }
        public Pelicula Pelicula { get; set; }  
        public List<Reserva> Reservas { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
    }
}
