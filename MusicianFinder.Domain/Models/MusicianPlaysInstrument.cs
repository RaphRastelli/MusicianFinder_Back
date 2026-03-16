using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianPlaysInstrument
    {
        public Musician? Musician { get; private set; }
        public Instrument? MusicianInstrument { get; private set; }
        public bool IsMainInstrument { get; private set; }
    }
}
