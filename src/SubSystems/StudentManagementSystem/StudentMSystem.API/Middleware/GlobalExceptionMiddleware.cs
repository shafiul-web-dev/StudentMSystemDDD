using System.Net;
using System.Text.Json;
using FluentValidation;

namespace StudentMSystem.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync( HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is ValidationException validationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new
                {
                    message = "Validation failed.",
                    errors = validationException.Errors.Select(error => new
                    {
                        field = error.PropertyName,
                        message = error.ErrorMessage
                    })
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorResponse = new
            {
                message = ex.Message
            };

            await context.Response.WriteAsync( JsonSerializer.Serialize(errorResponse));
        }
    }
}
