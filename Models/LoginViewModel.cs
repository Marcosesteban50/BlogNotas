using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace BlogdeNotas.Models
{
    public class LoginViewModel : Usuario
    {
        [Required(ErrorMessage = "{0} Es Requerido!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Recuerdame { get; set; }
    }
}
