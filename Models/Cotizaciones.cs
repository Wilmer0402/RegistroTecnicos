using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Cotizaciones
    {
        [Key]

        public int CotizacionId { get; set; }

        [Required(ErrorMessage = "Favor Complete este Campo")]

        public DateTime Fecha { get; set; } = DateTime.Now;


        [ForeignKey("Clientes")]

        public int ClienteId { get; set; }

        public Clientes Clientes { get; set; }

        [Required(ErrorMessage = "Favor Ingrese la Observacion de la Cotización")]
        [RegularExpression(@"[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]

        public string? Observacion { get; set; }

        [Required(ErrorMessage = "Favor Ingrese el Monto del Trabajo")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten Numeros")]

        public double Monto { get; set; }

        public ICollection<CotizacionesDetalle> CotizacionesDetalle { get; set; } = new List<CotizacionesDetalle>();
    }
}
