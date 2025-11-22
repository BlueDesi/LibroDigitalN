using System.Text.Json.Serialization;

namespace LibroDigital.Models
{
    public class EstudianteCurso
    {

            public int Id { get; set; }
            public int EstudianteId { get; set; }

            public int CursoId { get; set; }

            [JsonIgnore]

            public Curso? Curso { get; set; }
            [JsonIgnore]


            public Estudiante? Estudiante { get; set; }
            public DateTime? FechaInscripcion { get; set; } 


    }
}

