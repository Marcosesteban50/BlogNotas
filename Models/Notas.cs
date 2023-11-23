using System.ComponentModel.DataAnnotations;

namespace BlogdeNotas.Models
{
    public class Notas
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo {0} Es Requerido")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage ="El Campo {0} Es Requerido")]
        public string Nota { get; set; }


        
        public DateTime FechaCreacion { get; set; }
    }
}
