using CshBackendDev.Services;
using CshBackendDev.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<TokenAuthenticationMiddleware>();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();