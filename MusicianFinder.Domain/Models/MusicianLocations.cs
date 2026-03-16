using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLocations
    {
        public long MusicianId { get; private set; }
        public long LocationId { get; private set; }

        // Navigation properties (optionnelles mais utiles pour les includes EFCore)
        public Musician Musician { get; private set; } = null!;
        public Location MusicianLocation { get; private set; } = null!;
    }
}
