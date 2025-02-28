namespace quiz_app.DTO
{
    public class UserWithRoleDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
