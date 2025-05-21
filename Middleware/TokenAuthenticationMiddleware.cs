namespace CshBackendDev.Middleware;

public class TokenAuthenticationMiddleware
{
  private readonly RequestDelegate _next;
  private const string AUTH_TOKEN = "secrettoken123";

  public TokenAuthenticationMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    if (!context.Request.Headers.TryGetValue("Authorization", out var token) || token != AUTH_TOKEN)
    {
      context.Response.StatusCode = StatusCodes.Status401Unauthorized;
      await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
      return;
    }

    await _next(context);
  }
}
