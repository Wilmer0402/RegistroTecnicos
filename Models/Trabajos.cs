using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RegistroTecnicos.Models
{
    public class Trabajos
    {
        [Key]

        //TrabajoId, Fecha, ClienteId, TecnicoId, Descripcion, Monto

        public int TrabajoId { get; set; }
        [Required(ErrorMessage = "Favor Complete este Campo")]

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor Ingrese la Descripcion del Trabajo")]
        [RegularExpression(@"[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Favor Ingrese el Monto del Trabajo")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten Numeros")]

        public double Monto { get; set; }

        [ForeignKey("Clientes")]

        public int ClienteId { get; set; }

        public Clientes Clientes { get; set; }

        [ForeignKey("Tecnicos")]

        public int TecnicoId {  get; set; }

        public Tecnicos Tecnicos { get; set; }

        [ForeignKey("Prioridades")]

        public int PrioridadId { get; set; }

        public Prioridades Prioridades { get; set; }


    }
}
