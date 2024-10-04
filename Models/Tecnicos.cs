using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
	public class Tecnicos : IValidatableObject
	{
		[Key]
		public int TecnicoId { get; set; }

		[Required(ErrorMessage = "Favor, Ingresar el Nombre del Tecnico")]
		public string NombresTecnico { get; set; }

		[Required(ErrorMessage = "Favor, Ingrese el valor del sueldo por hora")]
		public float SueldoHora { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (SueldoHora <= 0)
			{
				yield return new ValidationResult(
					"El Sueldo por Hora debe ser mayor que 0",
					new[] { nameof(SueldoHora) });
			}
		}

        [ForeignKey("TiposTecnicos")]

        public int Id { get; set; }

        public TiposTecnicos? TiposTecnicos { get; set; }
    }
}
	