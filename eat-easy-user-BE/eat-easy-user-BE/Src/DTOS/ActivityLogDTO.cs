using System.ComponentModel.DataAnnotations.Schema;

namespace eat_easy_user_BE.Src.DTOS
{
    public class ActivityLogDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
