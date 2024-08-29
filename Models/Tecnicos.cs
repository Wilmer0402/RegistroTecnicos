using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        // Tecnico (ID, Nombre, SueldoHora)

        public int tecnicoId { get; set; }

        [Required(ErrorMessage = "Favor, Ingresar el Nombre del Tecnico")]
        public string nombreTecnico { get; set; }

        [Required(ErrorMessage = "Favor, Ingrese el valor del sueldo por hora")]
        public float sueldoHora { get; set; }
    }
}

