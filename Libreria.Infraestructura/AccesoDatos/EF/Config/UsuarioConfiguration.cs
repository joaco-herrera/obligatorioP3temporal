using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Nombre, voNombre =>
            {
                voNombre.Property(p => p.Value)
                         .HasColumnName("Nombre")
                         .IsRequired();
            });

            builder.OwnsOne(u => u.Apellido, voApellido =>
            {
                voApellido.Property(p => p.Value)
                         .HasColumnName("Apellido")
                         .IsRequired();
            });

            builder.OwnsOne(u => u.Email, voEmail =>
            {
                voEmail.Property(p => p.Value)
                       .HasColumnName("Email")
                       .IsRequired();
                voEmail.HasIndex(e => e.Value).IsUnique();
            });

            builder.OwnsOne(u => u.Password, voPassword =>
            {
                voPassword.Property(p => p.Value)
                          .HasColumnName("Password")
                          .IsRequired();
            });

            builder.Property(u => u.Rol)
                   .HasColumnName("Rol")
                   .IsRequired();

            // AGREGAR ESTO
            builder.Property(u => u.EquipoId)
                   .IsRequired();

            builder.HasOne(u => u.Equipo)
                   .WithMany(e => e.Usuarios)
                   .HasForeignKey(u => u.EquipoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}