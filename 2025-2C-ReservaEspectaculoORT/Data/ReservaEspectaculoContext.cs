using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.EntityFrameworkCore;


namespace _2025_2C_ReservaEspectaculoORT.Data
{
    public class ReservaEspectaculoContext : DbContext
    {
        public ReservaEspectaculoContext(DbContextOptions<ReservaEspectaculoContext> options) : base(options)
        {

        }
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Persona> Persona { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Sala> Sala { get; set; } = default!;
       

    }
}
    