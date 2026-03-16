using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianProjectType
    {
        public long MusicianId { get; private set; }
        public long ProjectTypeId { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public ProjectType MusProjectType { get; private set; } = null!;

        // Ctor
        // Empty for EntityFramework
        private MusicianProjectType() { }
    }
}
