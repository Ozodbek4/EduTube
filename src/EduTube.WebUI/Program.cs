using EduTube.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddWebApplicationBuilder();

var app = builder.Build();
app.UseWebApplicationMiddleware();

app.Run();