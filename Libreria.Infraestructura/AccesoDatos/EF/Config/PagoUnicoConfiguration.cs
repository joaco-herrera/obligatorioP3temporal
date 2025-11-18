using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class PagoUnicoConfiguration : IEntityTypeConfiguration<PagoUnico>
    {
        public void Configure(EntityTypeBuilder<PagoUnico> builder)
        {

            builder.Property(p => p.FechaPago)
                   .HasColumnName("FechaPago")
                   .IsRequired(false); 


            builder.Property(p => p.NumeroRecibo)
                   .HasColumnName("NumeroRecibo")
                   .HasMaxLength(50)
                   .IsRequired(false); 
        }
    }
}