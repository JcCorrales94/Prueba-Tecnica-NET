using BackendApp_Domain.DTO.Response;
using FluentValidation;
using System.Net;

namespace BackendApp.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public readonly RequestDelegate _requestDelegate;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.ToString());

            var errorMessageObject = new { ex.Message, InnerException = ex.InnerException?.ToString() };
            var errorMessage = System.Text.Json.JsonSerializer.Serialize(errorMessageObject);

            context.Response.ContentType = "application/json";

            if (ex is ValidationException)
            {
                var castException = ex as ValidationException;
                var listErrors = new List<ErrorResponseDTO>();
                foreach (var error in castException.Errors)
                {
                    listErrors.Add(new ErrorResponseDTO() { ErrorDescription = error.ErrorMessage });
                }

                errorMessage = System.Text.Json.JsonSerializer.Serialize(listErrors);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex is InvalidDataException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
