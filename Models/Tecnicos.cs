using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        // Tecnico (ID, Nombre, SueldoHora)

        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Favor, Ingresar el Nombre del Tecnico")]
        public string NombresTecnico { get; set; }

        [Required(ErrorMessage = "Favor, Ingrese el valor del sueldo por hora")]
        public float SueldoHora { get; set; }
    }
}

