using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace ContactsOnContainers.Shared.Middlewares.Errors
{
  public class ErrorHandlerMiddleware
  {
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception error)
      {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = error switch
        {
          _ => (int)HttpStatusCode.InternalServerError,// unhandled error
        };
        var result = JsonSerializer.Serialize(new { message = error?.Message });
        await response.WriteAsync(result);
      }
    }
  }
}
