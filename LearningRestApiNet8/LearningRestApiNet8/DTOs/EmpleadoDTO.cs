using System;

namespace LearningRestApiNet8.DTOs;

    /// <summary>
    /// DTO para representar los datos de un empleado.
    /// Se usa para evitar exponer directamente la entidad Empleado.
    /// </summary>
    public class EmpleadoDTO
    {
        public int Id { get; set; }  // Identificador del empleado
        public required string Nombre { get; set; }  // Nombre del empleado
        public required string Cargo { get; set; }  // Cargo dentro de la empresa
    }
