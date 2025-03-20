using System;
using System.Net;
using System.Text.Json;

namespace LearningRestApiNet8.Middleware;
/// <summary>
/// Middleware global para capturar y manejar errores en toda la aplicación.
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); // Llama al siguiente middleware en la cadena
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex); // Captura cualquier excepción no controlada
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Definir el código de estado HTTP
        var statusCode = exception switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound, // Error 404 si un recurso no existe
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // Error 401 si no tiene permisos
            _ => (int)HttpStatusCode.InternalServerError // Error 500 por defecto
        };

        // Crear la respuesta de error en formato JSON
        var errorResponse = new
        {
            error = exception.Message,
            status = statusCode
        };

        var result = JsonSerializer.Serialize(errorResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsync(result);
    }

}
