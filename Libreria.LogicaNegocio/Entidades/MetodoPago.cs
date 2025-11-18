using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Entidades
{
    public class MetodoPago : IEntity, IValidable, IEquatable<MetodoPago>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public MetodoPago() { }

        public MetodoPago(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrWhiteSpace(Tipo))
                throw new Exception("El tipo de método de pago es obligatorio.");

            var tiposPermitidos = new[] { "Credito", "Efectivo" };
            if (!tiposPermitidos.Contains(Tipo))
                throw new Exception($"Tipo de método de pago no válido. Debe ser: {string.Join(", ", tiposPermitidos)}");
        }

        public bool Equals(MetodoPago? other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
    }
}