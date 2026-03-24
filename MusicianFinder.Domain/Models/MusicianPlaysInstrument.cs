using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianPlaysInstrument
    {
        public int MusInstrumentId { get; private set; }
        public long MusicianIdFK { get; private set; }
        public int InstrumentIdFK { get; private set; }
        public bool IsMainInstrument { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public Instrument Instrument { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianPlaysInstrument() { }
    }
}
