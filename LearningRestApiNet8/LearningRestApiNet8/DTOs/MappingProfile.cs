using System;
using AutoMapper;
using LearningRestApiNet8.Models;
namespace LearningRestApiNet8.DTOs;

public class MappingProfile : Profile
{
    /// <summary>
    /// Configuración de AutoMapper para mapear entre Empleado y EmpleadoDTO.
    /// </summary>
    public MappingProfile()
        {
            // Mapea de Empleado a EmpleadoDTO y viceversa
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
        }
}
