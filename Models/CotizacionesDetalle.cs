using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class CotizacionesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("CotizacionId")]
        public int CotizacionId { get; set;}

        public Cotizaciones? Cotizaciones { get; set; }

        [InverseProperty("CotizacionesDetalle")]
        public virtual Cotizaciones Cotizacion { get; set; } = null!;


        [ForeignKey("ArticuloId")]
        public int ArticulosId { get; set; }
        public Articulos? Articulos { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Precio ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]
        public double Precio { get; set; }


    }
}
