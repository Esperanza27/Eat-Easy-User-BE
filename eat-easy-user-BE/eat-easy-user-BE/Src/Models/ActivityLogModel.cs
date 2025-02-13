using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eat_easy_user_BE.Src.Models
{
    public class ActivityLogModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("User_Id")]
        public int UserId { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        // Relazione con UserModel (facoltativa: se vuoi navigare da log a utente)
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

    }
}
