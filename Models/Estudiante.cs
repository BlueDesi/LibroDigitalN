using System.Text.Json.Serialization;

namespace LibroDigital.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Apellido { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        [JsonIgnore]
        public ICollection<Asistencia> Asistencias { get; set; }

    }
}
