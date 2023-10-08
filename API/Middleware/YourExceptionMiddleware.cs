using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Exceptions;
using Newtonsoft.Json;
using API.Entities;


namespace API.Middleware
{
    public class YourExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public YourExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SecureException ex)
        {
            LogSecureException(context, ex);
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            LogException(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private void LogSecureException(HttpContext context, SecureException ex)
    {
        var exceptionLog = new ExceptionLog
        {
            QueryParameters = context.Request.QueryString.ToString(),
            BodyParameters = "",  
            StackTrace = ex.StackTrace,
            ExceptionType = ex.GetType().Name,
            Message = ex.Message
        };

       
    }

    private void LogException(HttpContext context, Exception ex)
    {
        var exceptionLog = new ExceptionLog
        {
            QueryParameters = context.Request.QueryString.ToString(),
            BodyParameters = "", 
            StackTrace = ex.StackTrace,
            ExceptionType = ex.GetType().Name
        };

        
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        if (ex is SecureException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                type = ex.GetType().Name,
                id = Guid.NewGuid().ToString(),
                data = new { message = ex.Message }
            }));
        }
        else
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                type = "Exception",
                id = Guid.NewGuid().ToString(),
                data = new { message = "Internal server error ID = " + Guid.NewGuid().ToString() }
            }));
        }
    }
 }

}
