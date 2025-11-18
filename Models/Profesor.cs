using System.ComponentModel.DataAnnotations;

namespace LibroDigital.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        [Required]
        public string Dni { get; set; } = string.Empty;
        [Required]

        public string Email { get; set; } = string.Empty;

    }
}
