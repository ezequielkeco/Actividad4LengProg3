using Actividad3LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace Actividad3LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> _estudiantes = new List<EstudianteViewModel>()
        {
            new EstudianteViewModel()
            {
                NombreCompleto = "Pedro Gutierrez",
                Matricula = "SD-2022-01214",
                Carrera = "Odontología",
                CorreoInstitucional = "pguti@ufhec.edu.do",
                Telefono = "8095475412",
                //FechaNacimiento = "05/04/2000",
                Genero = "Masculino",
                Tanda = "Noche",
                //TipoDeIngreso = "Nuevo Ingreso",
                //EstaBecado = "Si",
                //PorcentajeBeca = "50%"
            },
            new EstudianteViewModel()
            {
                NombreCompleto = "Luis López",
                Matricula = "SD-2022-01524",
                Carrera = "Derecho",
                CorreoInstitucional = "llopez@ufhec.edu.do",
                Telefono = "8295330054",
                Genero = "Masculino",
                Tanda = "Tarde",
            },
            new EstudianteViewModel()
            {
                NombreCompleto = "Isabel Ruiz",
                Matricula = "SD-2022-00423",
                Carrera = "Enfermería",
                CorreoInstitucional = "iruiz@ufhec.edu.do",
                Telefono = "8498329178",
                Genero = "Femenino",
                Tanda = "Mañana",
            }
        };
        public EstudiantesController() {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(_estudiantes);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            var model = new EstudianteViewModel
            {
                CarrerasDisponibles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Ingeniería de Software", Text = "Ingeniería de Software" },
                    new SelectListItem { Value = "Enfermería", Text = "Enfermería" },
                    new SelectListItem { Value = "Contabilidad", Text = "Contabilidad" },
                    new SelectListItem { Value = "Ingeniería Eléctrica", Text = "Ingeniería Eléctrica" },
                    new SelectListItem { Value = "Derecho", Text = "Derecho" }
                },

                GenerosDisponibles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Masculino", Text = "Masculino" },
                    new SelectListItem { Value = "Femenino", Text = "Femenino" }
                },

                TipoDeIngreso = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Nuevo Ingreso", Text = "Nuevo Ingreso" },
                    new SelectListItem { Value = "Reingreso", Text = "Reingreso" },
                    new SelectListItem { Value = "Transferido", Text = "Transferido" }
                },

                TandasDisponibles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Mañana", Text = "Mañana" },
                    new SelectListItem { Value = "Tarde", Text = "Tarde" },
                    new SelectListItem { Value = "Noche", Text = "Noche" }
                }
            };

            return View(model);
        }

        [HttpPost]

        public IActionResult Registrar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _estudiantes.Add(model);
                ViewBag.Message = "El estudiante ha sido registrado.";
                return View(model);
            }

            return View(model);
        }
    }
}
