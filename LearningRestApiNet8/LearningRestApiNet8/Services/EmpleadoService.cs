using System;
using AutoMapper;
using LearningRestApiNet8.DTOs;
using LearningRestApiNet8.Models;
using LearningRestApiNet8.Repositories;

namespace LearningRestApiNet8.Services;

/// <summary>
    /// Implementación del servicio de empleados que usa AutoMapper y DTOs.
    /// </summary>
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repositorio;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor que recibe el repositorio de empleados y el mapeador.
        /// </summary>
        public EmpleadoService(IEmpleadoRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public IEnumerable<EmpleadoDTO> ObtenerTodos()
        {
            var empleados = _repositorio.ObtenerTodos();
            return _mapper.Map<IEnumerable<EmpleadoDTO>>(empleados);  // Convierte a DTO
        }

        public EmpleadoDTO ObtenerPorId(int id)
        {
            var empleado = _repositorio.ObtenerPorId(id);
            return _mapper.Map<EmpleadoDTO>(empleado);  // Convierte a DTO
        }

        public void Agregar(EmpleadoDTO empleadoDTO)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDTO);  // Convierte DTO a entidad
            _repositorio.Agregar(empleado);
        }

        public void Actualizar(EmpleadoDTO empleadoDTO)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDTO);  // Convierte DTO a entidad
            _repositorio.Actualizar(empleado);
        }

        public void Eliminar(int id) => _repositorio.Eliminar(id);
    }
