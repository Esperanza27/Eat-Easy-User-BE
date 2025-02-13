using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eat_easy_user_BE.Src.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        // Conserva solo l'hash della password, mai la password in chiaro.
        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("is_verified")]
        public bool IsVerified { get; set; }

        [Required]
        public string Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual UserProfileModel UserProfile { get; set; }

    }
}
