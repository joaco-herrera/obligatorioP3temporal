using Libreria.LogicaNegocio.InterfacesDominio;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public class TipoGasto : IEntity, IEquatable<TipoGasto>, IValidable
    {
        public int Id { get; set; } 
        public VoNombreGasto Nombre { get; set; }
        public VoDescripcionGasto Descripcion { get; set; }
        public TipoGasto() { }
        public TipoGasto(VoNombreGasto nombre, VoDescripcionGasto descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;

            Validable();
        }
        public void Validable()
        {
        }
        public bool Equals(TipoGasto? other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
        public void Update(TipoGasto obj)
        {
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
            Validable();
        }
    }
}