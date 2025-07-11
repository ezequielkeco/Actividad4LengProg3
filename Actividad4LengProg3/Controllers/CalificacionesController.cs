using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengProg3.Models
{
	public class CalificacionesViewModel
	{
		[Required(ErrorMessage = "Debe colocar su matrícula.")]
		public string MatriculaEstudiante {  get; set; }

		[Required(ErrorMessage = "Debe colocar el código de la materia.")]
		public string CodigoMateria { get; set; }

		[Required(ErrorMessage = "Debe colocar un valor válido.")]
        [Range(0, 10)]
		public string Nota {  get; set; }

		[Required(ErrorMessage = "Debe colocar un período válido.")]
		public string Periodo { get; set; }
    }
}
