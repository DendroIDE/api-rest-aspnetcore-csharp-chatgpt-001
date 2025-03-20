using System;

namespace LearningRestApiNet8.DTOs;

/// <summary>
/// DTO para el login de un usuario.
/// </summary>
public class LoginDTO
{
    public string Email { get; set; }  // Email del usuario
    public string Password { get; set; }  // Contraseña del usuario
}