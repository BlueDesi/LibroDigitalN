using System.Text.Json.Serialization;

namespace LibroDigital.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Turno { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Seccion { get; set; }=string.Empty;
        public string Nombre { get; set; } = string.Empty;

        public int ProfesorId { get; set; }

        public bool Activo { get; set; }
        [JsonIgnore]
        public Profesor? Profesor { get; set; }       // navegación


    }
}
