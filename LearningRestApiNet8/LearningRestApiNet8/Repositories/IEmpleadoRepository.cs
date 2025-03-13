using System;
using LearningRestApiNet8.Models;

namespace LearningRestApiNet8.Repositories;

public interface IEmpleadoRepository
{
    IEnumerable<Empleado> ObtenerTodos();
    Empleado ObtenerPorId(int id);
    void Agregar(Empleado empleado);
    void Actualizar(Empleado empleado);
    void Eliminar(int id);
    void Guardar();
}
