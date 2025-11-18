using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasDiscriminator<string>("TipoPago")
                   .HasValue<PagoUnico>("Unico")
                   .HasValue<PagoRecurrente>("Recurrente");

            builder.OwnsOne(p => p.Descripcion, desc =>
            {
                desc.Property(d => d.Value)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(500);
            });

            builder.OwnsOne(p => p.Monto, monto =>
            {
                monto.Property(m => m.Value)
                     .HasColumnName("Monto")
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");
            });

            builder.HasOne(p => p.MetodoPago)
                   .WithMany()
                   .HasForeignKey(p => p.MetodoPagoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.TipoGasto)
                   .WithMany()
                   .HasForeignKey(p => p.TipoGastoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Usuario)
                   .WithMany()
                   .HasForeignKey(p => p.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}