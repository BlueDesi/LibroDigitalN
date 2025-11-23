using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

       }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }


    }
}
