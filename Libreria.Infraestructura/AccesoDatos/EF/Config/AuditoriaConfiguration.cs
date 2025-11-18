using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestuctura.AccesoDatos.EF.Config
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Accion).IsRequired();
            builder.Property(a => a.Tabla).IsRequired();
            builder.Property(a => a.IdObjeto).IsRequired();
            builder.Property(a => a.Usuario).IsRequired();
            builder.Property(a => a.Fecha).IsRequired();
        }
    }
}