using LibroDigital.Context;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services.Cursos
{
    public class CursoService : ICursoService
    {

        


            private readonly AppDbContext _context;
            public CursoService(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Curso> CreateCursoAsync(Curso curso)
            {
            var profesorExiste = await _context.Profesores.AnyAsync(p => p.Id == curso.ProfesorId);
            if (!profesorExiste)
                throw new ArgumentException($"No existe un Profesor con Id = {curso.ProfesorId}");

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return curso;

        }
            public async Task<List<Curso>> GetCursosByProfesorAsync(int profesorId) =>
            await _context.Cursos
          .Where(c => c.ProfesorId == profesorId && c.Activo)
          .ToListAsync();



        public async Task<Curso?> GetCursoByIdAsync(int id)
            {
                return await _context.Cursos.FindAsync(id);


            }
      
        public async Task<bool> DeleteCursoAsync(int id)
            {
                var curso = await _context.Cursos.FindAsync(id);
                if (curso == null) return false;
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return true;

            }

            public async Task<List<Curso>> GetAllCursosAsync()
            {
                return await _context.Cursos.ToListAsync();
            }

           

            public async Task<Curso?> UpdateCursoAsync(int id, Curso curso)
            {
                var existing = await _context.Cursos.FindAsync(id);
                if (existing == null) return null;
                existing.Turno = curso.Turno;
                existing.Anio = curso.Anio;
                existing.Anio = curso.Anio;
                existing.Seccion = curso.Seccion;
                existing.Seccion = curso.Seccion;
                existing.Nombre = curso.Nombre;
                existing.ProfesorId = curso.ProfesorId;
                existing.Activo = curso.Activo;



                await _context.SaveChangesAsync();
                return existing;

            }
        }
    }

