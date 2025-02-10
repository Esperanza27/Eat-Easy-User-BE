namespace eat_easy_user_BE.Src.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
