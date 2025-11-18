using LibroDigital.Models;

namespace LibroDigital.Services
{
    public interface IEstudianteService
    {
        Task<List<Estudiante>> GetAllEstudiantesAsync();
        Task<Estudiante?> GetEstudianteByIdAsync(int id);
        Task<Estudiante> CreateEstudianteAsync(Estudiante estudiante);
        Task<Estudiante?> UpdateEstudianteAsync(int id, Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int id);

    }
}
