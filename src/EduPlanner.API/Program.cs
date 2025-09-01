using EduPlanner.API.Extensions;
using EduPlanner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); 


builder.Services.AddOpenApiDocumentation();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpoints();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApiDocumentation();
}

app.UseCors("AllowAll");

var apiGroup = app.MapGroup("api");
apiGroup.MapEndpoints();

app.UseHttpsRedirection();

app.Run();