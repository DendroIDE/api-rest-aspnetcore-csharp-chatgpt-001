using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningRestApiNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObtenerEmpleados()
        {
            var empleados = new List<object>
            {
                new { Id = 1, Nombre = "Juan", Apellido = "Perez", Cargo = "Gerente" },
                new { Id = 2, Nombre = "Maria", Apellido = "Gomez", Cargo = "Analista" },
                new { Id = 3, Nombre = "Pedro", Apellido = "Garcia", Cargo = "Desarrollador" }
            };

            return Ok(empleados);
        }
    }
}
