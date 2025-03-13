using System;
using LearningRestApiNet8.Models;
using LearningRestApiNet8.Repositories;

namespace LearningRestApiNet8.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _repositorio;

    public EmpleadoService(IEmpleadoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    IEnumerable<Empleado> IEmpleadoService.ObtenerTodos()
    {
        return _repositorio.ObtenerTodos();
    }

    Empleado IEmpleadoService.ObtenerPorId(int id)
    {
        return _repositorio.ObtenerPorId(id);
    }

    public void Agregar(Empleado empleado)
    {
        _repositorio.Agregar(empleado);
    }

    public void Actualizar(Empleado empleado)
    {
        _repositorio.Actualizar(empleado);
    }
    
    public void Eliminar(int id) => _repositorio.Eliminar(id);
}
