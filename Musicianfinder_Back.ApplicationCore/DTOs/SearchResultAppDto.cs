using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.DTOs
{
    public class SearchResultAppDto
    {
        public List<MusicianResultAppDto> Musicians { get; set; } = new();
        public int TotalCount { get; set; }
        public bool NoInstrumentMatch { get; set; }
    }

    public class MusicianResultAppDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
