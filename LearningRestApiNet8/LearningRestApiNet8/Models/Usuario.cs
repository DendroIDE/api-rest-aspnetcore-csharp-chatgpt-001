using System;
using Microsoft.AspNetCore.Identity;

namespace LearningRestApiNet8.Models;

/// <summary>
/// Representa a un usuario en el sistema.
/// Hereda de IdentityUser para aprovechar ASP.NET Identity.
/// </summary>
public class Usuario : IdentityUser
{
    public required string NombreCompleto { get; set; }  // Campo adicional para almacenar el nombre del usuario
}
