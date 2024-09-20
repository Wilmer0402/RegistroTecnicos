using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RegistroTecnicos.Models
{
	public class Prioridades
	{
		[Key]

		//PrioridadId, Descripcion, Tiempo
		
		public int PrioridadId { get; set; }
		
		[Required(ErrorMessage = "Favor Ingrese la Descripcion de la Prioridad del Trabajo")]
		[RegularExpression(@"[a-zA-Z\s]+$", ErrorMessage ="Solo se permiten letras")]

		public string? Descripcion { get; set; }

		[Required(ErrorMessage = "Favor Ingrese el Tiempo")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten Numeros")]

		public int Tiempo { get; set; }
	}
}
