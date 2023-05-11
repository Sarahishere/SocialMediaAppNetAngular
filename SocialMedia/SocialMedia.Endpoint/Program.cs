
using SocialMedia.Endpoint.Extentions;
using SocialMedia.Endpoint.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.UseHttpsRedirection();
app.UseApiVersioning();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();