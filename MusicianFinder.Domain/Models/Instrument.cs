using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Instrument
    {
        public int InstrumentId { get; private set; }
        public string InstrumentName { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private Instrument() { }

        // Ctor pour créer un instrument
        public Instrument( 
           string instrumentName) 
        { 
            InstrumentName = instrumentName; 
        }

        // Ctor pour récupérer un instrument
        public Instrument(int instrumentId, string instrumentName)
        {  
            InstrumentId = instrumentId; 
            InstrumentName = instrumentName; 
        }
    }
}
