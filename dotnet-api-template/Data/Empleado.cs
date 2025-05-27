
using System.ComponentModel.DataAnnotations;
namespace dotnet_api_template.Data
{

    public class Empleado : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(15)]
        public string Dni { get; set; }

        [Required]
        public int Sueldo { get; set; }

        public bool TieneSeguroPrivado { get; set; }
    }
}