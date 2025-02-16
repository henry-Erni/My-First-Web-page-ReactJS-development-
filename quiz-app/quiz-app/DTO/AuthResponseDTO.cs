namespace quiz_app.DTO
{
    public class AuthResponseDTO
    {
        public required string Username { get; set; }
        public required Guid UserId { get; set; }
        public required string Token { get; set; }
    }
}
