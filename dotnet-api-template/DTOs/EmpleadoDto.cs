using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_api_template.DTOs
{
    public class EmpleadoDto
    {
        public int? Id { get; set; }  // null para crear, valor para actualizar

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; }

        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 100 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^\d{6,15}$", ErrorMessage = "El DNI debe tener entre 6 y 15 dígitos numéricos")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio")]
        [Range(1, 999999, ErrorMessage = "El sueldo debe ser positivo y menor a 1 millón")]
        public int Sueldo { get; set; }

        public bool TieneSeguroPrivado { get; set; }
    }
}
