using Libreria.LogicaNegocio.InterfacesDominio;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Equipo : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoNombreEquipo Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public Equipo() { }

        public Equipo(VoNombreEquipo nombre)
        {
            Nombre = nombre;
            Validable();
        }

        public void Validable()
        {
            if (Nombre == null)
                throw new Exception("El nombre del equipo es obligatorio");
        }

        public bool Equals(Equipo? other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
    }
}