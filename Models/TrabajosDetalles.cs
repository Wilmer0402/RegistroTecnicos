using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class TrabajosDetalles
    {
        [Key]

        public int DetallesId { get; set; }

        [ForeignKey("Trabajos")]
        public int TrabajoId { get; set; }

        public Trabajos? Trabajos { get; set; }

        [ForeignKey("Articulos")]

        public int ArticulosId { get; set; }    

        public Articulos? Articulos { get; set; }

        [Required(ErrorMessage = "Favor Ingresar la Cantidad ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Precio ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public double Precio {get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Costo ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public double Costo { get; set; }

        public string? Descripcion { get; set; }


    }
}
