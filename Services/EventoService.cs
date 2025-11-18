using LibroDigital.Context;
using LibroDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroDigital.Services
{
    public class EventoService:IEventoService
    {


        private readonly AppDbContext _context;
        public EventoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;

        }

        public async Task<Evento?> GetEventosByIdAsync(int id)
        {
            return await _context.Eventos.FindAsync(id);


        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return false;
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Evento>> GetAllEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

       

        public async Task<Evento?> UpdateEventoAsync(int id, Evento evento)
        {
            var existing = await _context.Eventos.FindAsync(id);
            if (existing == null) return null;
            existing.Descripcion = evento.Descripcion;
        
            await _context.SaveChangesAsync();
            return existing;

        }
    }

}

