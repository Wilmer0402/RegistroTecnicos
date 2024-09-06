using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]
        // Id, Descripcion

        public int Id { get; set; }

        [Required(ErrorMessage = "Favor, Ingrese la Descripcion del Tecnico")]
        public string Descripcion { get; set; }

    }
}
