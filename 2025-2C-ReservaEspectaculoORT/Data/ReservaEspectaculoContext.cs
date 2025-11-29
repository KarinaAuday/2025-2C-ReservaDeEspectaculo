using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace _2025_2C_ReservaEspectaculoORT.Data
{
    public class ReservaEspectaculoContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ReservaEspectaculoContext(DbContextOptions<ReservaEspectaculoContext> options) : base(options)
        {

        }
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Persona> Persona { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Empleado> Empleado { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Sala> Sala { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.TipoSala> TipoSala { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Funcion> Funcion { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Reserva> Reserva { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Pelicula> Pelicula { get; set; } = default!;
        public DbSet<_2025_2C_ReservaEspectaculoORT.Models.Rol> Rol{get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //ModelBuilder.Entity<Pago>.property(p => p.Monto).HasColumnType("decimal")
            builder.Entity<IdentityUser<int>>().ToTable("Personas");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            builder.Entity<Persona>().HasIndex(s => s.Dni).IsUnique(); //Dni
//            builder.Entity<Sala>().HasIndex(s => s.Numero).IsUnique(); //Numero sala unica
//            builder.Entity<Pelicula>().HasIndex(p => p.Titulo).IsUnique(); //Nombre pelicula
    
        }
    }
}
    