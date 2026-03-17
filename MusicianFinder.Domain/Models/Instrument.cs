using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Instrument
    {
        public long InstrumentId { get; private set; }
        public string InstrumentName { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private Instrument() { }
    }
}
