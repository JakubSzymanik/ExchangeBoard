using System.Net;
using System.Text.Json;
using webapi.Errors;

namespace webapi.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;
        ILogger<ExceptionMiddleware> _logger;
        IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
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
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //ustaw kod odpowiedzi

                var response = _env.IsDevelopment() ?
                    new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) :
                    new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options); //ustawienie i odpowiednie zserializowanie ApiException w jsonie

                await context.Response.WriteAsync(json); //zapisanie zserializowanego ApiException do jsona
            }
        }
    }
}
