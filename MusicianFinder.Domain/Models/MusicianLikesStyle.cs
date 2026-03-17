using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLikesStyle
    {
        public long MusicianId { get; private set; }
        public long StyleId { get; private set; }
        public bool IsMainStyle { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public MusicStyle MusicianStyle { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianLikesStyle() { }
    }
}
