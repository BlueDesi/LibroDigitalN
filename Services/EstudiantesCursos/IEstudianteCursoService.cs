using LibroDigital.Models;

namespace LibroDigital.Services.EstudiantesCursos
{
    public interface IEstudianteCursoService
    {
        Task<List<EstudianteCurso>> GetAllEstudiantesCursosAsync();
        Task<EstudianteCurso?> GetEstudiantesCursosByIdAsync(int id);
        Task<EstudianteCurso> CreateEstudianteCursoAsync(EstudianteCurso estudiantecurso);
        Task<EstudianteCurso?> UpdateEstudianteCursoAsync(int id, EstudianteCurso estudiantecurso);
        Task<bool> DeleteEstudianteCursoAsync(int id);
        Task<List<EstudianteCurso>> GetEstudiantesCursosByProfesorAsync(int profesorId);
        Task<List<EstudianteCurso>> GetEstudiantesCursosByCursoAsync(int cursoId);
        Task<List<EstudianteCurso>> GetEstudiantesPorCursoAsync(int cursoId);


    }
}
