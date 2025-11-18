using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.Nombre, voNombre =>
            {
                voNombre.Property(p => p.Value)
                        .HasColumnName("Nombre")
                        .IsRequired();
            });

            builder.HasMany(e => e.Usuarios)
                   .WithOne(u => u.Equipo)
                   .HasForeignKey(u => u.EquipoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}