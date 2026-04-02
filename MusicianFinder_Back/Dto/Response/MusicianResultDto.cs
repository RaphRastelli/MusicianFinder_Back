namespace MusicianFinder_Back.WebAPI.Dto.Response
{
    public class MusicianResultDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
