using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eat_easy_user_BE.Src.Models
{
    public class UserProfileModel
    {
        [Key, ForeignKey("User")]
        [Column("User_Id")]
        public int UserId { get; set; } // Chiave primaria ed esterna verso UserModel

        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Il cognome è obbligatorio.")]
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Relazione 1:1 con UserModel
        public virtual UserModel User { get; set; }

    }
}
