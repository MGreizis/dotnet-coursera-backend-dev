using CshBackendDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();