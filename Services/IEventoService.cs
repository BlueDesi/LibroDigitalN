using LibroDigital.Models;

namespace LibroDigital.Services
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllEventosAsync();
        Task<Evento?> GetEventosByIdAsync(int id);
        Task<Evento> CreateEventoAsync(Evento evento);
        Task<Evento?> UpdateEventoAsync(int id, Evento evento);
        Task<bool> DeleteEventoAsync(int id);
    }
}
