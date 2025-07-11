
using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>()
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(estudiantes);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["MensajeError"] = "El nombre de usuario pasado no existe.";

                return RedirectToAction("Lista");
            }

            EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.NombreCompleto.Equals(id));

            if (estudianteActual == null)
            {
                TempData["MensajeError"] = "No existe el usuario indicado";

                return RedirectToAction("Lista");
            }

            return View(estudianteActual);
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
                estudiantes.Add(model);
                TempData["Mensaje"] = "El estudiante ha sido registrado.";
                return RedirectToAction("Lista");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.NombreCompleto.Equals(model.NombreCompleto));

                if (estudianteActual == null)
                {
                    TempData["MensajeError"] = "No existe el usuario indicado";

                    return RedirectToAction("Lista");
                }

                estudianteActual.NombreCompleto = model.NombreCompleto;
                estudianteActual.Matricula = model.Matricula;
                estudianteActual.Carrera = model.Carrera;
                estudianteActual.CorreoInstitucional = model.CorreoInstitucional;
                estudianteActual.Telefono = model.Telefono;
                estudianteActual.FechaNacimiento = model.FechaNacimiento;
                estudianteActual.Genero = model.Genero;
                estudianteActual.Tanda = model.Tanda;
                estudianteActual.TipoDeIngreso = model.TipoDeIngreso;
                estudianteActual.EstaBecado = model.EstaBecado;
                estudianteActual.PorcentajeBeca = model.PorcentajeBeca;

                TempData["Mensaje"] = "Usuario editado correctamente.";
                return RedirectToAction("Lista");
            }

            return View(model);
        }
    }
}