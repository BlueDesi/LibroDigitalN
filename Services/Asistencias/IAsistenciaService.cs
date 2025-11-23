using LibroDigital.Helpers;
using LibroDigital.Models;

namespace LibroDigital.Services.Asistencias
{
    public interface IAsistenciaService
    {

        Task<List<Asistencia>> GetAllAsistenciasAsync();
        Task<Asistencia?> GetAsistenciaByIdAsync(int id);
        Task<bool> DeleteAsistenciaAsync(int id);
        Task<ServiceResult<Asistencia>> CreateAsistenciaAsync(Asistencia asistencia);
        Task<ServiceResult<Asistencia>> UpdateAsistenciaAsync(int id, Asistencia asistencia);
    }
}
