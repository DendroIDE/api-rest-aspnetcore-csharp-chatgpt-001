using System;
using LearningRestApiNet8.DTOs;
using LearningRestApiNet8.Models;

namespace LearningRestApiNet8.Services;

    /// <summary>
    /// Interfaz para manejar la lógica de negocio de empleados utilizando DTOs.
    /// </summary>
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoDTO> ObtenerTodos();  // Retorna una lista de empleados en formato DTO
        EmpleadoDTO ObtenerPorId(int id);  // Retorna un empleado por su ID
        void Agregar(EmpleadoDTO empleadoDTO);  // Agrega un nuevo empleado
        void Actualizar(EmpleadoDTO empleadoDTO);  // Actualiza un empleado existente
        void Eliminar(int id);  // Elimina un empleado por su ID
    }
