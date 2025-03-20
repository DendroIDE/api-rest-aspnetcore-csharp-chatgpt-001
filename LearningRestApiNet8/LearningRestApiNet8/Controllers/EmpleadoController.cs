using LearningRestApiNet8.DTOs;
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

        /// <summary>
        /// Constructor que recibe el servicio de empleados.
        /// </summary>
        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        /// <summary>
        /// Obtiene todos los empleados en formato DTO.
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerEmpleados()
        {
            return Ok(_empleadoService.ObtenerTodos());
        }

        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult ObtenerEmpleado(int id)
        {
            try
            {
                var empleado = _empleadoService.ObtenerPorId(id);
                return Ok(empleado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Empleado no encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno en el servidor.", error = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo empleado a partir de un DTO.
        /// </summary>
        [HttpPost]
        public IActionResult CrearEmpleado([FromBody] EmpleadoDTO empleadoDTO)
        {
            _empleadoService.Agregar(empleadoDTO);
            return CreatedAtAction(nameof(ObtenerEmpleado), new { id = empleadoDTO.Id }, empleadoDTO);
        }

        /// <summary>
        /// Actualiza un empleado existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult ActualizarEmpleado(int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            if (id != empleadoDTO.Id)
                return BadRequest("El ID del empleado no coincide.");

            _empleadoService.Actualizar(empleadoDTO);
            return NoContent();
        }

        /// <summary>
        /// Elimina un empleado por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult EliminarEmpleado(int id)
        {
            _empleadoService.Eliminar(id);
            return NoContent();
        }
    }
}
