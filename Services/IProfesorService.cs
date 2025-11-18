using LibroDigital.Models;

namespace LibroDigital.Services
{
    public interface IProfesorService
    {
        Task<List<Profesor>> GetAllProfesoresAsync();
        Task<Profesor?> GetProfesorByIdAsync(int id);
        Task<Profesor> CreateProfesorAsync(Profesor profesor);
        Task<Profesor?> UpdateProfesorAsync(int id, Profesor profesor);
        Task<bool> DeleteProfesorAsync(int id);
    }
}
