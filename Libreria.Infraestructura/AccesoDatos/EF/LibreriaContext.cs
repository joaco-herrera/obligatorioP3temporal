using Libreria.Infraestuctura.AccesoDatos.EF.Config;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }



        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("Rol")
                .HasValue<Admin>("Admin")
                .HasValue<Gerente>("Gerente")
                .HasValue<Empleado>("Empleado");

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TipoGastoConfiguration());
            modelBuilder.ApplyConfiguration(new MetodoPagoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoUnicoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoRecurrenteConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriaConfiguration());
        }
    }
}