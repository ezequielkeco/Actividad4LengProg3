using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad3LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El nombre completo del estudiante es obligatorio")]
        [StringLength(40)]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Debe colocar una matrícula válida")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una carrera")]
        public string Carrera { get; set; }
        public List<SelectListItem> CarrerasDisponibles { get; set; }

        [Required(ErrorMessage = "Debe colocar un correo electrónico válido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(40)]
        public string CorreoInstitucional { get; set; }

        [Phone]
        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Ingrese un número de teléfono válido con el código de área")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe colocar la fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        public string Genero {  get; set; }
        public List<SelectListItem> GenerosDisponibles { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una tanda")]
        public string Tanda { get; set; }

        public List<SelectListItem> TandasDisponibles { get; set; }

        [Required(ErrorMessage = "Debe completar el tipo de ingreso")]
        public string TipoIngreso { get; set; }
        public List<SelectListItem> TipoDeIngreso { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 1 y 100")]
        public int? PorcentajeBeca {  get; set; }

        //[Required(ErrorMessage = "Debe aceptar los términos para el registro")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos para el registro")]
        public bool AceptarTerminos { get; set; }
    }
}
