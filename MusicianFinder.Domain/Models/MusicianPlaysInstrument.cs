using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianPlaysInstrument
    {
        public Musician? Musician { get; private set; }
        public IEnumerable<Instrument>? InstrumentList { get; private set; }
        public Instrument? MainInstrument { get; private set; }
    }
}
