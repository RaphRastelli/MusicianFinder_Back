using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLocation
    {
        public long MusicianId { get; private set; }
        public long LocationId { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public Location MusLocation { get; private set; } = null!;

        // Ctor
        // Empty for EntityFramework
        private MusicianLocation() { }
    }
}
