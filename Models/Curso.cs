using LibroDigital.Enums;
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
       
        public Profesor? Profesor { get; set; }
        [JsonIgnore]
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
        public DiaSemana DiaClase { get; set; } =DiaSemana.Lunes; // valor por defecto



    }
}
