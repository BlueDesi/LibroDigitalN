using LibroDigital.Context;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly AppDbContext _context;
        public ProfesorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Profesor> CreateProfesorAsync(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();
            return profesor;

        }

        public async Task<bool> DeleteProfesorAsync(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return false;
             _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Profesor>> GetAllProfesoresAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesor?> GetProfesorByIdAsync(int id)
        {
            return await _context.Profesores.FindAsync(id);


        }

        public async Task<Profesor?> UpdateProfesorAsync(int id, Profesor profesor)
        {
            var existing = await _context.Profesores.FindAsync(id);
            if (existing == null) return null;
            existing.Nombre = profesor.Nombre;
            existing.Apellido = profesor.Apellido;
            existing.Dni = profesor.Dni;
            existing.Email = profesor.Email;
            await _context.SaveChangesAsync();
            return existing;    

        }
    }
}
