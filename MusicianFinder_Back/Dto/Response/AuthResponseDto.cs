namespace MusicianFinder_Back.WebAPI.Dto.Response
{
    public class AuthResponseDto
    {
        public long Id { get; set; }   // ← nouveau
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
