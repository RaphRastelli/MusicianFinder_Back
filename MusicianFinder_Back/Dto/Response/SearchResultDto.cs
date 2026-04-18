namespace MusicianFinder_Back.WebAPI.Dto.Response
{
    public class SearchResultDto
    {
        public List<MusicianResultDto> Musicians { get; set; } = new();
        public int TotalCount { get; set; }
        public bool NoInstrumentMatch { get; set; }
        public bool NoMatch { get; set; }
    }
}
