using LearningRestApiNet8.Models;
using LearningRestApiNet8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningRestApiNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public IActionResult ObtenerEmpleados()
        {
            return Ok(_empleadoService.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerEmpleado(int id)
        {
            var empleado = _empleadoService.ObtenerPorId(id);
            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult CrearEmpleado([FromBody] Empleado empleado)
        {
            _empleadoService.Agregar(empleado);
            return CreatedAtAction(nameof(ObtenerEmpleado), new { id = empleado.Id }, empleado);
        }
    }
}
