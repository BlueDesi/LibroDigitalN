using System.Text.Json.Serialization;

namespace LibroDigital.Models
{
    public class Evento
    {

        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();


    }
}
