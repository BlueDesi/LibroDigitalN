using LibroDigital.Context;
using LibroDigital.Helpers;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services.Asistencias
{
    public class AsistenciaService : IAsistenciaService
    {

        private readonly AppDbContext _context;

        public AsistenciaService(AppDbContext context)
        {
            _context = context;
        }

        // ---------------------------
        // CREATE
        // ---------------------------
        public async Task<ServiceResult<Asistencia>> CreateAsistenciaAsync(Asistencia asistencia)
        {
            if (!await _context.Estudiantes.AnyAsync(e => e.Id == asistencia.EstudianteId))
                return ServiceResult<Asistencia>.Fail($"El EstudianteId {asistencia.EstudianteId} no existe.");

            if (!await _context.Cursos.AnyAsync(c => c.Id == asistencia.CursoId))
                return ServiceResult<Asistencia>.Fail($"El CursoId {asistencia.CursoId} no existe.");

            if (!await _context.Eventos.AnyAsync(ev => ev.Id == asistencia.EventoId))
                return ServiceResult<Asistencia>.Fail($"El EventoId {asistencia.EventoId} no existe.");

            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();

            return ServiceResult<Asistencia>.Ok(asistencia);
        }
        // ---------------------------
        // DELETE
        // ---------------------------
        public async Task<bool> DeleteAsistenciaAsync(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null) return false;

            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
            return true;
        }

        // ---------------------------
        // GET ALL
        // ---------------------------
        public async Task<List<Asistencia>> GetAllAsistenciasAsync()
        {
            return await _context.Asistencias
                .OrderBy(a => a.Fecha)
                .ToListAsync();
        }

        // ---------------------------
        // GET BY ID
        // ---------------------------
        public async Task<Asistencia?> GetAsistenciaByIdAsync(int id)
        {
            return await _context.Asistencias
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // ---------------------------
        // UPDATE
        // ---------------------------
        public async Task<ServiceResult<Asistencia>> UpdateAsistenciaAsync(int id, Asistencia asistencia)
        {
            // Buscar asistencia existente
            var existente = await _context.Asistencias.FindAsync(id);
            if (existente == null)
                return ServiceResult<Asistencia>.Fail($"Asistencia con Id {id} no encontrada.");

            // Validación FK: Estudiante
            if (!await _context.Estudiantes.AnyAsync(e => e.Id == asistencia.EstudianteId))
                return ServiceResult<Asistencia>.Fail($"El EstudianteId {asistencia.EstudianteId} no existe.");

            // Validación FK: Curso
            if (!await _context.Cursos.AnyAsync(c => c.Id == asistencia.CursoId))
                return ServiceResult<Asistencia>.Fail($"El CursoId {asistencia.CursoId} no existe.");

            // Validación FK: Evento
            if (!await _context.Eventos.AnyAsync(ev => ev.Id == asistencia.EventoId))
                return ServiceResult<Asistencia>.Fail($"El EventoId {asistencia.EventoId} no existe.");

            // Actualizar campos
            existente.EstudianteId = asistencia.EstudianteId;
            existente.CursoId = asistencia.CursoId;
            existente.EventoId = asistencia.EventoId;
            existente.Fecha = asistencia.Fecha;
            existente.Comentario = asistencia.Comentario;
            existente.Presente = asistencia.Presente;

            // Guardar cambios
            await _context.SaveChangesAsync();

            // Devolver éxito
            return ServiceResult<Asistencia>.Ok(existente);
        }


    }
}
