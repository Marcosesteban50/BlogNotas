using System.ComponentModel.DataAnnotations;

namespace BlogdeNotas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} Es Requerido!")]
        [EmailAddress(ErrorMessage = "Correo Electronico No Valido")]
        public string Email { get; set; }
        public string EmailNormalizado { get; set; }
        public string PasswordHash { get; set; }
        
    }
}
