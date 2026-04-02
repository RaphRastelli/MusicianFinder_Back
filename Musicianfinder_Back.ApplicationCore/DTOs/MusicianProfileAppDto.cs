using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.DTOs
{
    public class MusicianProfileAppDto
    {
        public string Username { get; set; } = string.Empty;
        public string? InstrumentPrincipal { get; set; }
        public string? Ability { get; set; }
        public List<string> InstrumentsSecondaires { get; set; } = new();
        public string? StylePrincipal { get; set; }
        public List<string> StylesSecondaires { get; set; } = new();
        public List<string> Locations { get; set; } = new();
        public List<string> ProjectTypes { get; set; } = new();
        public string? Availability { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
    }
}