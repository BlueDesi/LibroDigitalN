using LibroDigital.Models;

namespace LibroDigital.Services.Cursos
{
    public interface ICursoService
    {
        Task<List<Curso>> GetAllCursosAsync();
        Task<Curso?> GetCursoByIdAsync(int id);
        Task<Curso> CreateCursoAsync(Curso curso);
        Task<Curso?> UpdateCursoAsync(int id, Curso curso);
        Task<bool> DeleteCursoAsync(int id);
    }
}
