using event_planning_test_api.Domain.Exceptions;
using event_planning_test_api.Domain.Exceptions.Models;
using Microsoft.AspNetCore.Http;

namespace event_planning_test_api.Domain.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ConflictException exception)
        {
            await HandleConflictException(context, exception);
        }
        catch (VerifyUserEmailException exception)
        {
            await HandleVerifyUserEmailException(context, exception);
        }
    }

    private async Task HandleConflictException(HttpContext httpContext,
        Exception ex)
    {
        var exception = (ConflictException)ex;
        httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
        await httpContext.Response.WriteAsJsonAsync(
            new ExceptionResponse()
            {
                Title = exception.Message
            });
    }

    private async Task HandleVerifyUserEmailException(HttpContext httpContext,
        Exception ex)
    {
        var exception = (VerifyUserEmailException)ex;
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(
            new ExceptionResponse()
            {
                Title = exception.Message
            });
    }
}
