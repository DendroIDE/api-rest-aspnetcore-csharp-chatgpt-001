using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningRestApiNet8.Filters;

    /// <summary>
    /// Filtro de excepciones para capturar y manejar errores en los controladores.
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound, // Error 404 si no encuentra el recurso
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // Error 401 si falta autenticación
                _ => (int)HttpStatusCode.InternalServerError // Error 500 para errores internos
            };

            var response = new
            {
                error = context.Exception.Message,
                status = statusCode
            };

            context.Result = new ObjectResult(response) { StatusCode = statusCode };
            context.ExceptionHandled = true;
        }
    }
