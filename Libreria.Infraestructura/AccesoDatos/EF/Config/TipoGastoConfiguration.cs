using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class TipoGastoConfiguration : IEntityTypeConfiguration<TipoGasto>
    {
        public void Configure(EntityTypeBuilder<TipoGasto> builder)
        {
            builder.HasKey(t => t.Id);

            builder.OwnsOne(t => t.Nombre, voNombre =>
            {
                voNombre.Property(p => p.Value)
                        .HasColumnName("Nombre")
                        .IsRequired();
            });

            builder.OwnsOne(t => t.Descripcion, voDescripcion =>
            {
                voDescripcion.Property(p => p.Value)
                             .HasColumnName("Descripcion")
                             .IsRequired();
            });
        }
    }
}
