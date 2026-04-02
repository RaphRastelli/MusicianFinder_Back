using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.DTOs
{
    public class MusicianSearchAppDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int? Ability { get; set; }
        public int? Availability { get; set; }

        // Instruments du musicien
        public List<MusicianInstrumentAppDto> Instruments { get; set; } = new();

        // Locations du musicien
        public List<int> LocationIds { get; set; } = new();

        // ProjectTypes du musicien
        public List<int> ProjectTypeIds { get; set; } = new();

        // Styles du musicien
        public List<MusicianStyleAppDto> Styles { get; set; } = new();
    }

    public class MusicianInstrumentAppDto
    {
        public int InstrumentId { get; set; }
        public bool IsMainInstrument { get; set; }
    }

    public class MusicianStyleAppDto
    {
        public int StyleId { get; set; }
        public bool IsMainStyle { get; set; }
    }
}