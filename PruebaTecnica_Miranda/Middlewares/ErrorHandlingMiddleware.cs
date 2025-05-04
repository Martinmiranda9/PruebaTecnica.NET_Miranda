using System.Net;
using System.Text.Json;

namespace PruebaTecnica_Miranda.Middlewares
{
    // // Definicion de una clase middleware para manejar errores globales.
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        // // Constructor que recibe el siguiente middleware y el logger mediante inyección de dependencias.
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Método que se ejecuta por cada solicitud HTTP que pasa por este middleware.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en la solicitud: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        // Método estático para crear una respuesta JSON en caso de error.
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new
            {
                statusCode = (int)HttpStatusCode.InternalServerError,
                message = "Ocurrió un error inesperado.",
                details = exception.Message 
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }

    }
}
