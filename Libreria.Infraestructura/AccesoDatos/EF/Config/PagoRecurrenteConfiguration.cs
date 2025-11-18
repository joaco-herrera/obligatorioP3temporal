using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class PagoRecurrenteConfiguration : IEntityTypeConfiguration<PagoRecurrente>
    {
        public void Configure(EntityTypeBuilder<PagoRecurrente> builder)
        {

            builder.OwnsOne(p => p.Periodo, periodo =>
            {
                periodo.Property(per => per.FechaDesde)
                       .HasColumnName("FechaDesde")
                       .IsRequired(false); 

                periodo.Property(per => per.FechaHasta)
                       .HasColumnName("FechaHasta")
                       .IsRequired(false); 
            });
        }
    }
}