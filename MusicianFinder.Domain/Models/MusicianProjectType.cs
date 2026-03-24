using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianProjectType
    {
        public int MusProjectId { get; private set; }
        public long MusicianId { get; private set; }
        public int ProjectTypeId { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public ProjectType ProjectType { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianProjectType() { }
    }
}
