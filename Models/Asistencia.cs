namespace LibroDigital.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public int CursoId { get; set; }
        public string Comentario { get; set; }=string.Empty;
        public bool Presente { get; set; }
        public int EventoId { get; set; }
    }
}
