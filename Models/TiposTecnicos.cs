using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]
        // Tecnico (ID, Nombre, SueldoHora)

        public int Id { get; set; }

        [Required(ErrorMessage = "Favor, Ingresar el Nombre del Técnico")]
        public string NombresTecnico { get; set; }

        [Required(ErrorMessage = "Favor, Ingresar la descripcion del Técnico")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Favor, Ingrese el valor del sueldo por hora")]
        public float SueldoHora { get; set; }
    }
}
