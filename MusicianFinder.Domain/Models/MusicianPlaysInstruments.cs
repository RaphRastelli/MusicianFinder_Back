using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianPlaysInstruments
    {
        public long MusicianId { get; private set; }
        public long InstrumentId { get; private set; }
        public bool IsMainInstrument { get; private set; }

        // Navigation properties (optionnelles mais utiles pour les includes EFCore)
        public Musician Musician { get; private set; } = null!;
        public Instrument MusicianInstrument { get; private set; } = null!;
    }
}
