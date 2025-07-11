using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

	public class MateriasViewModel
	{
		[Required(ErrorMessage = "Debe colocar un código válido.")]
		public string Codigo { get; set; }

		[Required]
        [StringLength(100, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres.")]
		public string Nombre { get; set; }

		[Require(ErrorMessage = "Debe colocar la cantidad de créditos.")]
		[Range(1,10)]
		public string Creditos { get; set; }

		[Required(ErrorMessage = "Debe colocar la carrera.")]
		public string Carrera
    }
