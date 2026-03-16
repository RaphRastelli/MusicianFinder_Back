using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLikesStyles
    {
        public long MusicianId { get; private set; }
        public long StyleId { get; private set; }
        public bool IsMainStyle { get; private set; }

        // Navigation properties (optionnelles mais utiles pour les includes EFCore)
        public Musician Musician { get; private set; } = null!;
        public MusicStyle MusicianStyle { get; private set; } = null!;
    }
}
