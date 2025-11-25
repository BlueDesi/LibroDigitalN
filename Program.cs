using LibroDigital.Context;
using LibroDigital.Services;
using LibroDigital.Services.Asistencias;
using LibroDigital.Services.Cursos;
using LibroDigital.Services.EstudiantesCursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEstudianteCursoService, EstudianteCursoService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LibroDigital API",
        Version = "v1"
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
