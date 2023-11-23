using System.ComponentModel.DataAnnotations;

namespace BlogdeNotas.Models
{
    public class RegistroViewModel : Usuario
    {
        
       
        [Required(ErrorMessage ="{0} Es Requerido!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
