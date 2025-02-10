using System.ComponentModel.DataAnnotations;

namespace eat_easy_user_BE.Src.DTOS
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Il nome utente è obbligatorio.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria.")]
        [EmailAddress(ErrorMessage = "Formato email non valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria.")]
        [MinLength(6, ErrorMessage = "La password deve avere almeno 6 caratteri.")]
        public string Password { get; set; }
    }
}
