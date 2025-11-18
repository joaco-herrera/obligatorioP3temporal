using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoPeriodoPago : IValidable
    {
        public DateTime? FechaDesde { get; private set; }
        public DateTime? FechaHasta { get; private set; }
        public VoPeriodoPago() { }

        public VoPeriodoPago(DateTime fechaDesde, DateTime fechaHasta)
        {
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            Validable();
        }

        public void Validable()
        {
            if (!FechaDesde.HasValue || !FechaHasta.HasValue)
                throw new Exception("Las fechas son obligatorias.");

            if (FechaDesde.Value >= FechaHasta.Value)
                throw new Exception("La fecha desde debe ser anterior a la fecha hasta.");

            if (FechaDesde.Value < new DateTime(2000, 1, 1))
                throw new Exception("La fecha desde no puede ser anterior al año 2000.");

            if (FechaHasta.Value > DateTime.Now.AddYears(10))
                throw new Exception("La fecha hasta no puede superar los 10 años desde hoy.");

            if ((FechaHasta.Value.Year - FechaDesde.Value.Year) * 12 + FechaHasta.Value.Month - FechaDesde.Value.Month < 1)
                throw new Exception("El período debe ser de al menos 1 mes.");
        }

        public int CalcularCantidadMeses()
        {
            if (!FechaDesde.HasValue || !FechaHasta.HasValue)
                return 0;

            return ((FechaHasta.Value.Year - FechaDesde.Value.Year) * 12) +
                   (FechaHasta.Value.Month - FechaDesde.Value.Month) + 1;
        }
    }
}