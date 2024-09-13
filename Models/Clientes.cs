using System.ComponentModel.DataAnnotations;
namespace RegistroTecnicos.Models
{
    public class Clientes
    {
        [Key]

        // ClienteId, Nombres, WhatsApp

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Nombre del Cliente")]
            public string Nombres { get; set; }

        [Required (ErrorMessage = "Favor Ingrese el Numero de WhatsApp del Cliente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten Numeros")]

        public string WhatsApp { get; set; }
    }
}
