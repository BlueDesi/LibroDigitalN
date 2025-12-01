using LibroDigital.Context;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services.EstudiantesCursos
{
    public class EstudianteCursoService : IEstudianteCursoService
    {
        private readonly AppDbContext _context;

        public EstudianteCursoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EstudianteCurso> CreateEstudianteCursoAsync(EstudianteCurso estudianteCurso)
        {
            // Validar estudiante
            var existeEstudiante = await _context.Estudiantes.AnyAsync(e => e.Id == estudianteCurso.EstudianteId);
            if (!existeEstudiante)
                throw new ArgumentException($"No existe un Estudiante con Id = {estudianteCurso.EstudianteId}");

            // Validar curso
            var existeCurso = await _context.Cursos.AnyAsync(c => c.Id == estudianteCurso.CursoId);
            if (!existeCurso)
                throw new ArgumentException($"No existe un Curso con Id = {estudianteCurso.CursoId}");

            _context.EstudiantesCursos.Add(estudianteCurso);
            await _context.SaveChangesAsync();
            return estudianteCurso;
        }

        public async Task<List<EstudianteCurso>> GetAllEstudiantesCursosAsync()
        {
            return await _context.EstudiantesCursos
                .Include(ec => ec.Estudiante)
                .Include(ec => ec.Curso)
                .OrderBy(ec => ec.Curso.Anio)       
                .ThenBy(ec => ec.Curso.Seccion)     
                .ThenBy(ec => ec.Curso.Turno)       
                .ToListAsync();
        }

        public async Task<EstudianteCurso?> GetEstudiantesCursosByIdAsync(int id)
        {
            return await _context.EstudiantesCursos
                .Include(ec => ec.Estudiante)
                .Include(ec => ec.Curso)
                .FirstOrDefaultAsync(ec => ec.Id == id);
        }

        public async Task<EstudianteCurso?> UpdateEstudianteCursoAsync(int id, EstudianteCurso estudianteCurso)
        {
            var existing = await _context.EstudiantesCursos.FindAsync(id);
            if (existing == null) return null;

            // Validar FK
            if (!await _context.Estudiantes.AnyAsync(e => e.Id == estudianteCurso.EstudianteId))
                throw new ArgumentException($"No existe un Estudiante con Id = {estudianteCurso.EstudianteId}");
            if (!await _context.Cursos.AnyAsync(c => c.Id == estudianteCurso.CursoId))
                throw new ArgumentException($"No existe un Curso con Id = {estudianteCurso.CursoId}");

            existing.EstudianteId = estudianteCurso.EstudianteId;
            existing.CursoId = estudianteCurso.CursoId;
            existing.FechaInscripcion = estudianteCurso.FechaInscripcion;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteEstudianteCursoAsync(int id)
        {
            var existing = await _context.EstudiantesCursos.FindAsync(id);
            if (existing == null) return false;

            _context.EstudiantesCursos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<EstudianteCurso>> GetEstudiantesCursosByProfesorAsync(int profesorId)
        {
            return await _context.EstudiantesCursos
                .Include(ec => ec.Estudiante)
                .Include(ec => ec.Curso)
                .Where(ec => ec.Curso.ProfesorId == profesorId)    // FILTRO CLAVE
                .OrderBy(ec => ec.Curso.Anio)
                .ThenBy(ec => ec.Curso.Seccion)
                .ThenBy(ec => ec.Curso.Turno)
                .ToListAsync();
        }

        public async Task<List<EstudianteCurso>> GetEstudiantesCursosByCursoAsync(int cursoId)
        {
            return await _context.EstudiantesCursos
                .Include(ec => ec.Estudiante)
                .Where(ec => ec.CursoId == cursoId)
                .ToListAsync();
        }

        
        public async Task<List<EstudianteCurso>> GetEstudiantesPorCursoAsync(int cursoId)
        {
            return await _context.EstudiantesCursos
                .Include(ec => ec.Estudiante)  // ⚡ Esto es clave
                .Where(ec => ec.CursoId == cursoId)
                .ToListAsync();
        }
    }
}
