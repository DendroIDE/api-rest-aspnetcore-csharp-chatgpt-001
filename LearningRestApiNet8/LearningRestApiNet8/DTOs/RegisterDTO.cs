using System;

namespace LearningRestApiNet8.DTOs;

/// <summary>
/// DTO para el registro de un nuevo usuario.
/// </summary>
public class RegisterDTO
{
    public string Nombre { get; set; }  // Nombre completo del usuario
    public string Email { get; set; }  // Correo electrónico del usuario
    public string Password { get; set; }  // Contraseña del usuario
    public string ConfirmPassword { get; set; }  // Confirmación de la contraseña
}
