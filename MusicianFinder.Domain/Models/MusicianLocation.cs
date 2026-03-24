using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLocation
    {
        public int MusicianLocId { get; private set; }
        public long MusicianIdFK { get; private set; }
        public int LocationIdFK { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public Location Location { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianLocation() { }
    }
}
