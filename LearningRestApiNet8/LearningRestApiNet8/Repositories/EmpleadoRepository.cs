using System;
using LearningRestApiNet8.Data;
using LearningRestApiNet8.Models;

namespace LearningRestApiNet8.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly ApplicationDbContext _context;

    public EmpleadoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Empleado> ObtenerTodos() => _context.Empleados.ToList();

    public Empleado ObtenerPorId(int id)
    {
        var empleado = _context.Empleados.Find(id);
        if (empleado == null)
        {
            throw new KeyNotFoundException($"Empleado with id {id} not found.");
        }
        return empleado;
    }

    public void Agregar(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        Guardar();
    }

    public void Actualizar(Empleado empleado)
    {
        _context.Empleados.Update(empleado);
        Guardar();
    }

    public void Eliminar(int id)
    {
        var empleado = ObtenerPorId(id);
        if (empleado != null)
        {
            _context.Empleados.Remove(empleado);
            Guardar();
        }
    }

    public void Guardar() => _context.SaveChanges();
}

