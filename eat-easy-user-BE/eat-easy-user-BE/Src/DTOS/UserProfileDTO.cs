using System.ComponentModel.DataAnnotations;

namespace eat_easy_user_BE.Src.DTOS
{
    public class UserProfileDTO
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Il cognome è obbligatorio.")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
