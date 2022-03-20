using System.Net;
using Newtonsoft.Json;
using ParkingRush.Application.Exceptions;
using BadRequestException = SendGrid.Helpers.Errors.Model.BadRequestException;
using NotFoundException = SendGrid.Helpers.Errors.Model.NotFoundException;

namespace ParkingRush.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string result = JsonConvert.SerializeObject(new {error = exception.Message});
        switch (exception)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
        }

        httpContext.Response.StatusCode = (int) statusCode;
        return httpContext.Response.WriteAsync(result);
    }
}