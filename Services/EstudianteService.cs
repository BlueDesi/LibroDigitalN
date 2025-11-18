using LibroDigital.Context;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services
{
    public class EstudianteService:IEstudianteService
    {


        private readonly AppDbContext _context;
        public EstudianteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Estudiante> CreateEstudianteAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return estudiante;

        }

        public async Task<Estudiante?> GetEstudianteByIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);


        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return false;
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Estudiante>> GetAllEstudiantesAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Profesor?> GetProfesorByIdAsync(int id)
        {
            return await _context.Profesores.FindAsync(id);


        }

        public async Task<Estudiante?> UpdateEstudianteAsync(int id, Estudiante Estudiante)
        {
            var existing = await _context.Estudiantes.FindAsync(id);
            if (existing == null) return null;
            existing.Nombre = Estudiante.Nombre;
            existing.Apellido = Estudiante.Apellido;
            existing.Email = Estudiante.Email;
            await _context.SaveChangesAsync();
            return existing;

        }
    }

}

