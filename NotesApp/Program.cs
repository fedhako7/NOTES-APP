using Microsoft.OpenApi.Models;
using NotesAppAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Notes API",
        Version = "v1",
        Description = "A simple API for managing notes"
    });
});

// Configure dependency injection
builder.Services.Configure<NotesService>(builder.Configuration);
builder.Services.AddSingleton<NotesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();

