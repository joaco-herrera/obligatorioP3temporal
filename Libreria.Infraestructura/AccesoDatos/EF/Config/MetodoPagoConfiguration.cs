using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class MetodoPagoConfiguration : IEntityTypeConfiguration<MetodoPago>
    {
        public void Configure(EntityTypeBuilder<MetodoPago> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Tipo)
                   .HasColumnName("Tipo")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData(
                new MetodoPago { Id = 1, Tipo = "Credito" },
                new MetodoPago { Id = 2, Tipo = "Efectivo" }
            );
        }
    }
}