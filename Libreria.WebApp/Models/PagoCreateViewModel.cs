using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Libreria.WebApp.Models
{
    public class PagoCreateViewModel
    {
        [Required(ErrorMessage = "El tipo de pago es obligatorio")]
        [Display(Name = "Tipo de Pago")]
        public string TipoPago { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "La descripción debe tener entre 3 y 500 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, 999999999.99, ErrorMessage = "El monto debe ser mayor a 0")]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [Display(Name = "Método de Pago")]
        public int MetodoPagoId { get; set; }

        [Required(ErrorMessage = "El tipo de gasto es obligatorio")]
        [Display(Name = "Tipo de Gasto")]
        public int TipoGastoId { get; set; }

        [Display(Name = "Fecha de Pago")]
        public DateTime? FechaPago { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El número de recibo debe tener entre 3 y 50 caracteres")]
        [Display(Name = "Número de Recibo")]
        public string? NumeroRecibo { get; set; }

        [Display(Name = "Fecha Desde")]
        public DateTime? FechaDesde { get; set; }

        [Display(Name = "Fecha Hasta")]
        public DateTime? FechaHasta { get; set; }

        public IEnumerable<SelectListItem>? MetodosPago { get; set; }
        public IEnumerable<SelectListItem>? TiposGasto { get; set; }
    }
}