using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Articulos
    {

        [Key]

        public int ArticulosId { get; set; }    

        [Required(ErrorMessage = "Favor Ingresar la Descripcion")]
         public string Descripcion { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Costo")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public double Costo { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Precio")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public double Precio { get; set; }

        [Required(ErrorMessage = "Favor Ingresar la  Existencia")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

        public int Existencia { get; set; }



    }
}
